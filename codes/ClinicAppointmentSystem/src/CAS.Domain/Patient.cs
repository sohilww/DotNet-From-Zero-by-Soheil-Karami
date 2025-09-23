using CAS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Domain;
public class Patient
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ContactInfo { get; private set; }

    public List<Appointment> Appointments { get; private set; } = new();

    public Patient(Guid id, string firstName, string lastName, string contactInfo)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        ContactInfo = contactInfo;
    }

    public void AddAppointment(Appointment appointment)
    {
        Appointments.Add(appointment);
    }
}
