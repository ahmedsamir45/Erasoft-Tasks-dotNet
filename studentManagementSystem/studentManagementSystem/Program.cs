namespace AccountMangeMentSystem
{
    internal class Program
    {
        class Student(int StudentId, string Name, int Age, List<Course> Courses)
        {
            public int StudentId = StudentId;
            public string Name = Name;
            int Age = Age;
            public List<Course> Courses = Courses;
            public string PrintDetails()
            {
                string courses_text = "";
                if (Courses.Count != 0)
                {

                    foreach (var item in Courses)
                    {
                        courses_text += item.title + " ";
                    }
                }
                else
                {
                    courses_text = "courses is empty!";
                }
                return $"student id: {this.StudentId} - name: {this.Name} - age:{this.Age} - courses: {courses_text}";
            }

            public bool Enroll(Course course)
            {
                Courses.Add(course);
                Console.WriteLine($"course {course.title} added! to {this.Name}");
                return true;
            }
        }
        class Instructor(int InstructorId, string Name, string Specialization)
        {
            public int InstructorId = InstructorId;
            public string Name = Name;
            public string Specialization = Specialization;
            public string PrintDetails()
            {
                return $"instructorid: {this.InstructorId} - name: {this.Name} - specialization: {this.Specialization} ";
            }
        }
        class Course(int CourseId, string title, Instructor instructor)
        {
            public int CourseId = CourseId;
            public string title = title;
            public Instructor instructor = instructor;
            public string PrintDetails()
            {
                return $"course id: {this.CourseId} - title: {this.title} - instructor: {this.instructor.Name} ";
            }

        }
        class StudentManager
        {
            public List<Student> Students = [
                new Student(
                    123,
                    "ahmed",
                    19,
                    new List<Course>
                    {
                        new Course(1, "mathematics", new Instructor(1, "Dr. Smith", "Math")),
                        new Course(2, "chemistry", new Instructor(2, "Dr. Jones", "Chemistry"))
                    }
                )
            ];
            public List<Course> Courses = [
                new Course(1, "mathematics", new Instructor(1, "Dr. Smith", "Math")),
                new Course(2, "chemistry", new Instructor(2, "Dr. Jones", "Chemistry"))
                ];
            public List<Instructor> Instructors = [
                new Instructor(1,"islam","computer science"),
                new Instructor(2,"mohamed","science"),
                ];
            public bool AddStudent(Student student)
            {
                this.Students.Add(student);
                Console.WriteLine($"student ${student.Name} added!");
                return true;

            }
            public bool AddCourse(Course course)
            {
                this.Courses.Add(course);
                Console.WriteLine($"course ${course.title} added!");
                return true;
            }
            public bool AddInstructor(Instructor instructor)
            {
                this.Instructors.Add(instructor);
                Console.WriteLine($"course ${instructor.Name} added!");
                return true;
            }
            public Student FindStudent(int studentId)
            {
                foreach (var item in Students)
                {
                    if (item.StudentId == studentId)
                    {
                        return item;
                    }
                }
                Console.WriteLine("not found");
                return null;
            }

            public Student FindStudentByName(string name)
            {
                foreach (var item in Students)
                {
                    if (item.Name == name)
                    {
                        return item;
                    }
                }
                Console.WriteLine("not found");
                return null;
            }
            public Course FindCourseByName(string name)
            {
                foreach (var item in Courses)
                {
                    if (item.title == name)
                    {
                        return item;
                    }
                }
                Console.WriteLine("not found");
                return null;
            }
            public Course FindCourse(int courseid)
            {
                foreach (var item in this.Courses)
                {
                    if (item.CourseId == courseid)
                    {
                        return item;
                    }
                }
                Console.WriteLine("not found");
                return null;
            }
            public Instructor FindInstructor(int instructorID)
            {
                foreach (var item in this.Instructors)
                {
                    if (item.InstructorId == instructorID)
                    {
                        return item;
                    }
                }
                Console.WriteLine("not found");
                return null;
            }
            public bool EnrollStudentInCourse(int studentId, int courseId)
            {
                if (this.FindStudent(studentId) != null && this.FindCourse(courseId) != null)
                {
                    Student student = this.FindStudent(studentId);
                    student.Enroll(this.FindCourse(courseId));
                    return true;
                }
                return false;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("""
                                a. Add Student 
                                b. Add Instructor
                                c. Add Course (hint: select the instructor by id)
                                d. Enroll Student in Course
                                e. Show All Students
                                f. Show All Courses
                                g. Show All Instructors
                                h. Find the student by id or name
                                k. Fine the course by id or name
                                q. Exit
                """);
            bool isQuite = false;
            StudentManager school = new StudentManager();
            while (!isQuite)
            {
                Console.Write("choose the operation from the menu:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        // add student
                        Console.WriteLine("Enter id  of Student:");
                        int stid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name of Student:");
                        string stname = Console.ReadLine();
                        Console.WriteLine("Enter age of Student:");
                        int stage = Convert.ToInt32(Console.ReadLine());
                        Student student = new Student(stid, stname, stage, []);
                        school.AddStudent(student);
                        break;
                    case "b":
                        // add instructor
                        Console.WriteLine("Enter id  of instructor:");
                        int insIid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name of instructor:");
                        string instName = Console.ReadLine();
                        Console.WriteLine("Enter spicialization of instructor:");
                        String instSpicialization = Console.ReadLine();
                        Instructor instructor = new Instructor(insIid, instName, instSpicialization);
                        school.AddInstructor(instructor);
                        break;
                    case "c":
                        // add course
                        Console.WriteLine("Enter id  of course:");
                        int cid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name of course:");
                        string cname = Console.ReadLine();
                        Console.WriteLine("Enter id of instructor:");
                        foreach (var item in school.Instructors)
                        {
                            Console.WriteLine(item.PrintDetails());
                        }
                        int instructorId = Convert.ToInt32(Console.ReadLine());
                        Course course = new Course(cid, cname, school.FindInstructor(instructorId));
                        school.AddCourse(course);
                        break;
                    case "e":
                        // show students
                        foreach (var item in school.Students)
                        {
                            Console.WriteLine(item.PrintDetails());
                        }
                        break;
                    case "g":
                        // show instructors
                        foreach (var item in school.Instructors)
                        {
                            Console.WriteLine(item.PrintDetails());
                        }
                        break;
                    case "f":
                        // show courses
                        foreach (var item in school.Courses)
                        {
                            Console.WriteLine(item.PrintDetails());
                        }
                        break;
                    // quite
                    case "d":
                        Console.WriteLine("Students:");
                        foreach (var item in school.Students)
                        {
                            Console.WriteLine(item.PrintDetails());
                        }
                        Console.WriteLine("=================");
                        Console.WriteLine("Courses:");
                        foreach (var item in school.Courses)
                        {
                            Console.WriteLine(item.PrintDetails());
                        }
                        Console.WriteLine("enter student id");
                        int stuid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter course id");
                        int course_id = Convert.ToInt32(Console.ReadLine());
                        school.EnrollStudentInCourse(stuid, course_id);
                        break;
                    case "h":
                        Console.WriteLine("Enter id or name of the student");
                        var searchStudent = Console.ReadLine();
                        Student foundStudent = null;
                        if (int.TryParse(searchStudent, out int searchId))
                        {
                            foundStudent = school.FindStudent(searchId);
                        }
                        else if (!string.IsNullOrEmpty(searchStudent))
                        {
                            foundStudent = school.FindStudentByName(searchStudent);
                        }
                        if (foundStudent != null)
                        {
                            Console.WriteLine(foundStudent.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        break;
                    case "k":
                        Console.WriteLine("Enter id or name of the course");
                        var searchCourse = Console.ReadLine();
                        Course foundCourse = null;
                        if (int.TryParse(searchCourse, out int searchCourseId))
                        {
                            foundCourse = school.FindCourse(searchCourseId);
                        }
                        else if (!string.IsNullOrEmpty(searchCourse))
                        {
                            foundCourse = school.FindCourseByName(searchCourse);
                        }
                        if (foundCourse != null)
                        {
                            Console.WriteLine(foundCourse.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("course not found");
                        }
                            //Console.WriteLine(foundCourse.PrintDetails());
                        break;
                    case "q":
                        isQuite = true;
                        break;
                }
            }
        }
    }
}
