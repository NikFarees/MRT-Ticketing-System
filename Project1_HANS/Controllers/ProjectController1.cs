using Microsoft.AspNetCore.Mvc;
using Project1_HANS.Models;
using System.Net.Sockets;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Project1_HANS.MailSettings;

namespace Project1_HANS.Controllers
{
    public class ProjectController1 : Controller
    {

        private readonly IConfiguration configuration;
        public ProjectController1(IConfiguration config)
        {
            this.configuration = config;
        }

        // Method to get the database list
        IList<MRTSungaiBulohModel> GetDbList()
        {
            IList<MRTSungaiBulohModel> dbList = new List<MRTSungaiBulohModel>();
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("TicketConnStr"));

            string sql = @"SELECT * FROM MRTLineTicket";

            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dbList.Add(new MRTSungaiBulohModel()
                    {
                        ViewId = reader.GetString(0),
                        ViewDateTime = reader.GetDateTime(1),
                        Name = reader.GetString(2),
                        IC = reader.GetString(3),
                        Email = reader.GetString(4),
                        StartStation = reader.GetString(5),
                        EndStation = reader.GetString(6),
                        TicketType = reader.GetString(7),
                        Citizen = reader.GetInt32(8),
                        Student = reader.GetInt32(9),
                        SeniorCitizen = reader.GetInt32(10),
                        Disable = reader.GetInt32(11),
                        Amount = reader.GetDouble(12)
					}) ;
                }
            }

            catch
            {
                RedirectToAction("Error");
            }

            finally
            {
                conn.Close();
            }

            return dbList;
        }

        // Management Table
        public IActionResult Index()
        {
            IList<MRTSungaiBulohModel> dbList = GetDbList();
			return View(dbList);
        }

        // Report
		public IActionResult FullReport()
		{
			IList<MRTSungaiBulohModel> dbList = GetDbList();

			// Calculate totals
			int totalStudent = dbList.Sum(item => item.Student);
			int totalDisable = dbList.Sum(item => item.Disable);
			int totalCitizen = dbList.Sum(item => item.Citizen);
			int totalSeniorCitizen = dbList.Sum(item => item.SeniorCitizen);
			int totalPeople = totalStudent + totalDisable + totalCitizen + totalSeniorCitizen;
			double totalAmountFare = dbList.Sum(item => item.Amount);


            // Calculate most and least popular start and end stations
            var startStationCounts = dbList.GroupBy(item => item.StartStation).Select(group => new { Station = group.Key, Count = group.Count() });
            var endStationCounts = dbList.GroupBy(item => item.EndStation).Select(group => new { Station = group.Key, Count = group.Count() });

            // Most popular start station                                                          retreave first element or by default if no element
            var mostPopularStartStation = startStationCounts.OrderByDescending(item => item.Count).FirstOrDefault()?.Station;
            // Least popular start station 
            var leastPopularStartStation = startStationCounts.OrderBy(item => item.Count).FirstOrDefault()?.Station;

            // Most popular end station
            var mostPopularEndStation = endStationCounts.OrderByDescending(item => item.Count).FirstOrDefault()?.Station;
            // Least popular end station
            var leastPopularEndStation = endStationCounts.OrderBy(item => item.Count).FirstOrDefault()?.Station;



            // Set ViewBag properties
            ViewBag.TotalStudent = totalStudent;
			ViewBag.TotalDisable = totalDisable;
			ViewBag.TotalCitizen = totalCitizen;
			ViewBag.TotalSeniorCitizen = totalSeniorCitizen;
			ViewBag.TotalPeople = totalPeople;
			ViewBag.TotalAmountFare = totalAmountFare;
			ViewBag.TotalTicket = dbList.Count();
            ViewBag.MostPopularStartStation = mostPopularStartStation;
            ViewBag.LeastPopularStartStation = leastPopularStartStation;
            ViewBag.MostPopularEndStation = mostPopularEndStation;
            ViewBag.LeastPopularEndStation = leastPopularEndStation;


            return View(dbList);
		}

        // MRT TABLE
		public IActionResult MRTSungaiBulohKajangLine() 
        {
            MRTSungaiBulohModel model = new MRTSungaiBulohModel();
            return View(model);
        }

        // Customer Purchase Ticket
		[HttpGet]
        public IActionResult PurchaseTicket()
        {
            MRTSungaiBulohModel ticket = new MRTSungaiBulohModel();
            return View(ticket);
        }

        // Customer Ticket Invoice
        [HttpPost]
        public IActionResult PurchaseTicket(MRTSungaiBulohModel ticket) 
        {
            if (ModelState.IsValid)
            {
                if (ticket.Citizen == 0 && ticket.Student == 0 && ticket.SeniorCitizen == 0 && ticket.Disable == 0)
                {
                    ModelState.AddModelError("", "At least one field should have a value greater than zero.");
                    return View(ticket);
                }

                SqlConnection conn = new SqlConnection(configuration.GetConnectionString("TicketConnStr"));
                SqlCommand cmd = new SqlCommand("spInsertTicket", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ticketId", ticket.TicketId);
				cmd.Parameters.AddWithValue("@ticketDateTime", ticket.TicketDateTime);
				cmd.Parameters.AddWithValue("@purchaserName", ticket.Name);
                cmd.Parameters.AddWithValue("@purchaserIc", ticket.IC);
                cmd.Parameters.AddWithValue("@purchaserEmail", ticket.Email);
                cmd.Parameters.AddWithValue("@startStation", ticket.StartStation);
                cmd.Parameters.AddWithValue("@endStation", ticket.EndStation);
                cmd.Parameters.AddWithValue("@ticketType", ticket.TicketType);
                cmd.Parameters.AddWithValue("@citizen", ticket.Citizen);
                cmd.Parameters.AddWithValue("@student", ticket.Student);
                cmd.Parameters.AddWithValue("@seniorcitizen", ticket.SeniorCitizen);
                cmd.Parameters.AddWithValue("@disable", ticket.Disable);
                cmd.Parameters.AddWithValue("@amount", ticket.Amount);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return View(ticket);
                }
                finally
                {
                    conn.Close();
                }

                return View("PurchaseTicketInvoice", ticket);
            }
            else 
            {
                return View(ticket);
            }
        }

        // Ticket Details
		public IActionResult Details(string id)
		{
			IList<MRTSungaiBulohModel> dbList = GetDbList();
			var result = dbList.First(x => x.ViewId == id);

			return View(result);
		}

        // Delete Ticket
		[HttpGet]
		public IActionResult Delete(string id)
		{
			IList<MRTSungaiBulohModel> dbList = GetDbList();
			var result = dbList.First(x => x.ViewId == id);

			return View(result);
		}

        // Delete Ticket That Been Confirmed
        [HttpPost, ActionName("Delete")] 
		public IActionResult ConfirmDelete(string id)
		{
			SqlConnection conn = new SqlConnection(configuration.GetConnectionString("TicketConnStr"));
			SqlCommand cmd = new SqlCommand("spDeleteTicket", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ticketId", id);

			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
			finally
			{
				conn.Close();
			}
		}

        // Search Bar
		public IActionResult SearchIndex(string searchString = "")
		{
			IList<MRTSungaiBulohModel> dbList = GetDbList();
			var result = dbList.Where(x => x.ViewId.ToLower().Contains(searchString.ToLower()) ||
			x.Name.ToLower().Contains(searchString.ToLower())).OrderBy(x => x.Name).ThenByDescending(x => x.ViewDateTime);

			return View("Index", result);
		}

        // Ticket Mailing
		public IActionResult SendMail(string id)
		{
			IList<MRTSungaiBulohModel> dbList = GetDbList();
			var result = dbList.First(x => x.ViewId == id);

			var subject = "Ticket Information " + result.ViewId;
			var body = "Ticket id: " + result.ViewId + "<br>" +
				"Date and time: " + result.ViewDateTime + "<br>" +
				"Purchaser name: " + result.Name + "<br>" +
                "Purchaser ic: " + result.IC + "<br>" +
                "Start Station: " + result.StartStation + "<br>" +
				"End Station: " + result.EndStation + "<br>" +
				"Citizen: " + result.Citizen + "<br>" +
				"Student: " + result.Student + "<br>" +
				"Senior Citizen: " + result.SeniorCitizen + "<br>" +
				"Disable: " + result.Disable + "<br>" +
				"Amount: " + result.Amount.ToString("c2");

			var mail = new Mail(configuration);

			if (mail.Send(configuration["Gmail:Username"], result.Email, subject, body))
			{
				ViewBag.Message = "Status: " + "Mail successfully sent to " + result.Email;
				ViewBag.Body = body;
			}
			else
			{
				ViewBag.Message = "Status: " + "Sent Mail Failed";
				ViewBag.Body = "";
			}
			return View(result);
		}

    }
}
