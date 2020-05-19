using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    class Patient
    {
        public string name;
        public int age;
        public Doctor doctor;

        // Constructor to give patient name and age
        public Patient(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Gets hospital
        public void AdmitTo(Hospital hospital)
        {
            hospital.AdmitPatient(this);
        }
    }
}
