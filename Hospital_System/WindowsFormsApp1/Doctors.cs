
public enum Gender_doc
{
    Male,
    Female,
    Other
}

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public Gender_doc Gender { get; set; }
    public string Specialization { get; set; }
    public string HospitalAffiliation { get; set; }
    public string Qualifications { get; set; }

    public Doctor(int id, string name, string email, int age, Gender_doc gender,
        string specialization, string hospital, string qualifications)
    {
        Id = id;
        Name = name;
        Email = email;
        Age = age;
        Gender = gender;
        Specialization = specialization;
        HospitalAffiliation = hospital;
        Qualifications = qualifications;
    }
}

