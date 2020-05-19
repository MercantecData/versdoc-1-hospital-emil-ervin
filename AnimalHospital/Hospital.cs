using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    class Hospital
    {
        public string name;

        public List<Patient> patients = new List<Patient>(); 
        public List<Doctor> doctors = new List<Doctor>();

        // Constructer to the hospital a name
        public Hospital(string name)
        {
            this.name = name;
        }

        // Adds patient to patients list
        public void AdmitPatient(Patient patient)
        {
            if(patients.Contains(patient)) // Checks if patient already exists
            {
                Console.WriteLine("Patient already admitted to {0}.", name);
            } else
            {
                patients.Add(patient); // Adds patient to patients list
                Console.WriteLine("{0} was admitted to {1} successfully", patient.name, name);
            }
        }

        // Removes patient from list
        public void DischargePatient(Patient patient)
        {
            if(!patients.Contains(patient)) // Checks if patient exists
            {
                Console.WriteLine("Patient not in this hospital");
            } else
            {
                Console.WriteLine($"{patient.name} was in successfully discharged from the {name}");
                patients.Remove(patient); // Removes patient from list
            }
        }

        // Function finds patient (Obj) by name
        public Patient FindPatientByName(string name)
        {
            foreach(var p in patients) // Loops through patient list
            {
                if(p.name == name) // Checks if name is in the list
                {
                    return p; // returns patient object
                }
            }

            return null; // If the name isnt on the list, it returns null
        }

    }
}
