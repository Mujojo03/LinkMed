namespace LinkMed.Models
{
    public static class Department
    {
        public static string GetDepartmentBySpecialty(string specialty)
        {
            switch (specialty.ToLower())
            {
                case "cardiology": return "Cardiology";
                case "neurology": return "Neurology";
                case "pediatrics": return "Pediatrics";
                default: return "General Medicine";
            }
        }
    }
}
