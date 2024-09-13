using LinkMed.IServices;
using LinkMed.Models;

namespace LinkMed.Services
{
    public class UserRegistrationSercvice : IUserRegistrationService
    {
        //a list for users
        private readonly List<User> _users = new List<User> 
        {
        new User { Username = "John", Email = "john@gmail.com", Password = "123John" },
        new User { Username = "Jane", Email = "jane@gmail.com", Password = "123Jane" },
        new User { Username = "Alex", Email = "jane@gmail.com", Password = "123Alex" }
        };


        //a list for doctors
        private readonly List<Doctor> _doctors = new List<Doctor>
        {
            new Doctor { Username = "DrSmith", Email = "drsmith@gmail.com", Password = "123Smith", Specialty = "Cardiology", Department = "Cardiology" },
            new Doctor { Username = "DrJack", Email = "drjack@gmail.com", Password = "123Jack", Specialty = "Neurology", Department = "Neurology" },
            new Doctor { Username = "DrJane", Email = "drjoy@gmail.com", Password = "123Joy", Specialty = "Pediatrics", Department = "Pediatrics" }
        };

        //a list for appointments
        private readonly List<Appointment> _appointments = new List<Appointment>();

        //check if user/doctor exists
        public bool UserExists(string username, string email)
        {
            return _users.Any(u => u.Username == username || u.Email == email) ||
                   _doctors.Any(d => d.Username == username || d.Email == email);
        }

        //create a user
        public bool CreateUser(string username, string email, string password)
        {
            if(!_users.Any(u => u.Username == username || u.Email == email))
            {
                _users.Add(new User { Email = email, Username = username, Password = password });
                return true;
            }
            return false;
        }

        //create a doctor
        public bool CreateDoctor(string username, string email, string password, string specialty, string department)
        {
            if (!_doctors.Any(d => d.Username == username || d.Email == email))
            {
                _doctors.Add(new Doctor { Email = email, Username = username, Password = password, Specialty = specialty, Department = department });
                return true;
            }
            return false;
        }


        //methods to retrieve users and doctors if needed
        public List<User> GetAllUsers()
        {
            return _users;
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctors;
        }

        public bool BookAppointment(string username, DateTime appointmentDate, string facility)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                var appointment = new Appointment
                {
                    AppointmentDate = appointmentDate,
                    Facility = facility,
                    Username = username,
                };
                _appointments.Add(appointment);
                return true;
            }
            return false;
        }
        public Appointment GetAppointment(string username)
        {
            return _appointments.FirstOrDefault(a => a.Username == username);
        }
    }
}
