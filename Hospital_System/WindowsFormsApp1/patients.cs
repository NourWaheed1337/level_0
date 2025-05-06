public enum Gender_pat
{
    Male,
    Female,
    Other
}


class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public Gender_pat Gender { get; set; }
    public string TreatmentPlan { get; set; }
    public string Diagnosis { get; set; }
    public string InsuranceProvider { get; set; }

    public Patient(int id, string name, string email, int age, Gender_pat gender, string treatmentPlan, string diagnosis, string insuranceProvider)
    {
        Id = id;
        Name = name;
        Email = email;
        Age = age;
        Gender = gender;
        TreatmentPlan = treatmentPlan;
        Diagnosis = diagnosis;
        InsuranceProvider = insuranceProvider;
    }
}
