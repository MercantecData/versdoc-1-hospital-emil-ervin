using System;

namespace AnimalHospital
{
    class Program
    {
        // Makes an object from hospital
        public static Hospital hospital;
        static void Main(string[] args)
        {
            hospital = InitializeHospital();
            while (MainMenu()) {}

            Console.WriteLine("Goodbye!");
        }

        // Menu where you can click from 0 to 5 
        static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to {0}. You have the following options:", hospital.name);
            Console.WriteLine("1. Admit a patient to the hospital");
            Console.WriteLine("2. Discharge a patient");
            Console.WriteLine("3. See a list of all patients in the hospital");
            Console.WriteLine("4. See a list of all doctors in the hospital");
            Console.WriteLine("5. Assign a specific doctor to a specific patient");
            Console.WriteLine("0. Quit the Program");
            Console.WriteLine();

            // Saves input to k
            var k = Console.ReadKey().KeyChar;
            if(k == '1')
            {
                AdmitPatient(); // Press 1 to admitpatient 
            } 
            else if(k == '2')
            {
                DischargePatient(); // Press 2 to dischargepatient
            } 
            else if(k == '3')
            {
                listPatients(); // Press 3 to listpatiens
            }
            else if (k == '4')
            {
                listDoctors(); // Press 4 to list doctors 
            }
            else if (k == '5')
            {
                AssignDoctorToPatient(); // Press 5 to assagindoctortopatient 
            }
            else if (k == '0')
            {
                return false; // stops the program
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(); // Waiting for input
            return true;
        }

        static void AdmitPatient()
        {
            string name;
            int age;

            Console.WriteLine("What is the patients name?");
            name = Console.ReadLine(); // Gets patient name

            Console.WriteLine("What is the patients age?");
            while(!int.TryParse(Console.ReadLine(), out age)) // Checks if the input is a number, else you should try again 
            {
                Console.WriteLine("You must write a number, try again");
            }

            new Patient(name, age).AdmitTo(hospital); // Patient is created
        }

        static void DischargePatient()
        {
            string name;

            Console.WriteLine("What is the patients name?"); // Asking for the patients name 
            name = Console.ReadLine();

            Patient person = hospital.FindPatientByName(name); // Finds patients name, by name

            hospital.DischargePatient(person);  // It removes the patient
        }

        static void listPatients()
        {
            Console.WriteLine("NAME, AGE\n----------");
            for (int i = 0; i < hospital.patients.Count; i++) // Loops throguh the patients list
            {
                Console.WriteLine($"{hospital.patients[i].name}, {hospital.patients[i].age}"); // Prints the patients name and age
            }
        }

        static void listDoctors()
        {
            Console.WriteLine("NAME, SPECIALITY\n-----------------");
            for (int i = 0; i < hospital.doctors.Count; i++) // Loops through the doctor list
            {
                Console.WriteLine($"{hospital.doctors[i].name}, {hospital.doctors[i].speciality}"); // Prints the doctors name and speciality
            }
        }

        static void AssignDoctorToPatient()
        {
            Console.WriteLine("What is the doctors name?");
            string doctorName = Console.ReadLine(); // Gets doctorname

            int doctorIndex = hospital.doctors.FindIndex(a => a.name == doctorName); // Gets index of doctor on the list

            while (doctorIndex == -1) // Checks if doctor exists
            {
                Console.WriteLine("Doctor does not exist, try again");
                Console.WriteLine("What is the doctors name?");
                doctorName = Console.ReadLine(); // Gets new doctorname
                doctorIndex = hospital.doctors.FindIndex(a => a.name == doctorName);  // Gets the index of the new doctorname on the list
            }

            Console.WriteLine("What is the patients name?");
            string name = Console.ReadLine(); // Gets patients name

            Patient person = hospital.FindPatientByName(name); // Finds patient by name 

            while (person == null) // If patient does not exist
            {
                Console.WriteLine("Patient does not exist, try again");

                Console.WriteLine("What is the patients name?");
                name = Console.ReadLine(); // Gets new patient name 

                person = hospital.FindPatientByName(name); // Gets patient by name 
            }

            hospital.doctors[doctorIndex].assignedPatients.Add(person); // Adding patient to the doctors "assignedPatients" list 
            Console.WriteLine($"Doctor ({hospital.doctors[doctorIndex].name}) was successfully asigned to the patient {person.name}");
        }

        static Hospital InitializeHospital()
        {
            Hospital hospital = new Hospital("Animal Hospital"); // Creates a new hospital object 

            hospital.doctors.AddRange(new Doctor[] // Adding the doctors 
            {
                new Doctor("Matt Tennant", "Spinal Injury"),
                new Doctor("David Smith", "Knee Injury"),
                new Doctor("Jodie Tyler", "Oncology"),
                new Doctor("Rose Whitaker", "Intensive Care")
            });

            return hospital;
        }
    }
}