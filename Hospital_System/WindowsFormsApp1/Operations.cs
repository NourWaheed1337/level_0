using System;

public enum OperationStatus
{
    Scheduled,
    InProgress,
    Completed,
    Cancelled
}

public class Operation
{
    public int Id { get; set; }
    public string OperationName { get; set; }
    public string Department { get; set; }
    public string ScheduledBy { get; set; }
    public DateTime OperationDate { get; set; }
    public int DurationMinutes { get; set; }
    public int PatientId { get; set; }
    public string SurgeonName { get; set; }
    public OperationStatus Status { get; set; }
    public string Notes { get; set; }

    public Operation(int id, string name, string dept, string scheduledBy, DateTime date,
        int duration, int patientId, string surgeon, OperationStatus status, string notes)
    {
        Id = id;
        OperationName = name;
        Department = dept;
        ScheduledBy = scheduledBy;
        OperationDate = date;
        DurationMinutes = duration;
        PatientId = patientId;
        SurgeonName = surgeon;
        Status = status;
        Notes = notes;
    }
}
