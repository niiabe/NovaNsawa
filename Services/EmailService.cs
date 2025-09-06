using System.Net;
using System.Net.Mail;
using NovaNsawa.Models; // Changed from MyLandingPage.Models

namespace NovaNsawa.Services // Changed from MyLandingPage.Services
{
    public class EmailService
    {
        private readonly string _smtpHost = "smtp.gmail.com"; // Fixed: _ not *
        private readonly int _smtpPort = 587; // Fixed: _ not *
        private readonly string _adminEmail = "niiabeabbey@gmail.com"; // Fixed: _ not *
        private readonly string _senderEmail = "your-sender@example.com"; // Fixed: _ not *
        private readonly string _senderPassword = "your-app-password"; // Fixed: _ not *

        public async Task SendContactEmailsAsync(ContactFormModel contact)
        {
            // Send confirmation email to user
            await SendUserConfirmationAsync(contact);
            
            // Send notification email to admin
            await SendAdminNotificationAsync(contact);
        }

        private async Task SendUserConfirmationAsync(ContactFormModel contact)
        {
            string subject = "Thank you for contacting us";
            string body = $@"
                <h2>Thank you for your message!</h2>
                <p>Dear {contact.Name},</p>
                <p>We have received your message and will get back to you soon.</p>
                
                <h3>Your Message Details:</h3>
                <p><strong>Subject:</strong> {contact.Subject}</p>
                <p><strong>Phone:</strong> {contact.Phone}</p>
                <p><strong>Message:</strong><br>{contact.Message.Replace("\n", "<br>")}</p>
                
                <p>Best regards,<br>Your Team</p>
            ";

            await SendEmailAsync(_senderEmail, contact.Email, subject, body); // Fixed: _ not *
        }

        private async Task SendAdminNotificationAsync(ContactFormModel contact)
        {
            string subject = $"New Contact Form Submission: {contact.Subject}";
            string body = $@"
                <h2>New Contact Form Submission</h2>
                
                <p><strong>Name:</strong> {contact.Name}</p>
                <p><strong>Email:</strong> {contact.Email}</p>
                <p><strong>Phone:</strong> {contact.Phone}</p>
                <p><strong>Subject:</strong> {contact.Subject}</p>
                <p><strong>Message:</strong><br>{contact.Message.Replace("\n", "<br>")}</p>
                
                <p><strong>Submitted:</strong> {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>
            ";

            await SendEmailAsync(_senderEmail, _adminEmail, subject, body); // Fixed: _ not *
        }

        private async Task SendEmailAsync(string from, string to, string subject, string body)
        {
            using var client = new SmtpClient(_smtpHost, _smtpPort); // Fixed: _ not *
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_senderEmail, _senderPassword); // Fixed: _ not *
            client.EnableSsl = true;

            var message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = true;

            await client.SendMailAsync(message);
        }
    }
}