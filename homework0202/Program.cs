using homework0202;

#region Task1
Exam exam1 = new Exam("Exam1", new DateTime(2024, 10, 10, 14, 00, 00));
Exam exam2 = new Exam("Exam2", new DateTime(2024, 10, 06, 14, 00, 00));
Exam exam3 = new Exam("Exam3", new DateTime(2024, 10, 1, 14, 00, 00));

List<Exam> exams = new List<Exam> { exam1, exam2, exam3 };

////subjectı A ilə başlayan examləri göstərin
var hasA = exams.FindAll(x => x.Subject.Contains('a'));
Console.WriteLine("\n subjectı A ilə başlayan examlər ");
foreach (var exam in exams)
{
    if (exam.Subject.Contains("a"))
    {
        Console.WriteLine($" Exam: {exam.Subject}  Date: {exam.ExamDate} ");
    }
}
ShowAll(hasA);

////Keçmiş imtahanları göstərin
Console.WriteLine("\n Keçmiş imtahan tarixləri ");
var ExamDate = exams.FindAll(x => x.ExamDate < DateTime.Now);
ShowAll(ExamDate);


////1 ay-dan daha az vaxt sonra baş tutacaq imtahanları göstərin
Console.WriteLine("\n 1 ay-dan daha az vaxt sonra baş tutacaq imtahanlar");
var lastExam = exams.FindAll(x =>(x.ExamDate - DateTime.Now).TotalDays < 30 && (x.ExamDate - DateTime.Now).TotalDays > 0);
ShowAll(lastExam);

//// saat 08:00 - də olan ihtahanları göstərin
Console.WriteLine("\n saat 08:00 - də olan imhtahanları göstərin");
var List = exams.FindAll(x => (x.ExamDate.Hour == 8 && x.ExamDate.Minute==0));
ShowAll(List);

////kecmiş tarixli imtahanları listdən lisin

Console.WriteLine("\n kecmiş tarixli imtahanları listdən lisin");
Console.WriteLine("Bütün imtahanlar :");
ShowAll(exams);
var deleteList = exams.FindAll(x => x.ExamDate < DateTime.Now);
Console.WriteLine("\nSilinmiş imtahanlar");
ShowAll(deleteList);
exams.RemoveAll(x => x.ExamDate < DateTime.Now);
Console.WriteLine("\nAll Products");
ShowAll(exams);


////- subjecti riyaziyyat olan bir imtahanın listdə olub olmadığını yoxlayın
var hasMath = exams.FindAll(x => x.Subject.Contains("riyaziyyat"));
Console.WriteLine("\n subjecti riyaziyyat olan bir imtahanın listdə olub olmadığını yoxlayın ");
foreach (var exam in exams)
{
    if (exam.Subject.Contains("riyaziyyat"))
    {
        Console.WriteLine($" Exam: {exam.Subject}  Date: {exam.ExamDate} ");
    }
}
ShowAll(hasMath);

////- subjecti riyazzıyyat olan imtahanı göstərin

Console.WriteLine("\n subjecti riyazzıyyat olan imtahanı göstərin ");
foreach (var exam in exams)
{
    if (exam.Subject.Contains("riyaziyyat"))
    {
        Console.WriteLine($" Exam: {exam.Subject}  Date: {exam.ExamDate} ");
    }
}
ShowAll(hasMath);

#endregion

#region Task 2
// 2ci taskdaki əməliyyatlar üçün menu pəncərəsi qrup edin
// (misalçün add new exam, show passed exam, remove passsed exams və s
// operationları olan bir menu pəncərəsi ilə dataları console-dan götürərək əməliyyat aparın.
string opt;
do
{
    Console.WriteLine("-----------------------------Menu-------------------------");
    Console.WriteLine("1 -> Add");
    Console.WriteLine("2 -> Show passed exam ");
    Console.WriteLine("3 -> Remove passsed exams");
    Console.WriteLine("4 -> Show All");
    Console.WriteLine("0 -> Exit ");
    Console.WriteLine("-----------------------------------------------------------------");
    opt = Console.ReadLine();
    switch (opt)
    {
        case "1":
            //Add proses
            addProduct();
            break;
        case "2":
            Console.WriteLine("\n Show passed exam ");
            var ExamDate1 = exams.FindAll(x => x.ExamDate < DateTime.Now);
            ShowAll(ExamDate1);

            break;
        case "3":
            Console.WriteLine("\n Remove passsed exams");
            Console.WriteLine("All exams :");
            ShowAll(exams);
            var deleteList1 = exams.FindAll(x => x.ExamDate < DateTime.Now);
            Console.WriteLine("\nRemove Exam");
            ShowAll(deleteList1);
            exams.RemoveAll(x => x.ExamDate < DateTime.Now);
            Console.WriteLine("\n All Exam");
            ShowAll(exams);
            break;
        case "4":
            Console.WriteLine("Show All");
            ShowAll(exams);
            break;
        case "0":
            Console.WriteLine("Finish");
            break;

        default:
            Console.WriteLine("Wrong !");
            break;
    }


} while (opt != "0");
void addProduct()
{
    string subject;
    string dateTimeStr;
    DateTime ExamDate;

    do
    {
        Console.WriteLine("Subject: ");
        subject = Console.ReadLine();
    }
    while (string.IsNullOrWhiteSpace(subject));

    do
    {
        Console.WriteLine("Exam Date (e.g., 'yyyy-MM-dd HH:mm'): ");
        dateTimeStr = Console.ReadLine();
    }
    while (!DateTime.TryParse(dateTimeStr, out ExamDate));

    Exam newexam = new Exam(subject, ExamDate);
    exams.Add(newexam);
    Console.WriteLine("\nExam Added!");
    ShowAll(exams);
}
static void ShowAll(List<Exam> exams)
{
    foreach (var exam in exams)
    {
        Console.WriteLine($" Exam: {exam.Subject}  Date: {exam.ExamDate} ");
    }
}
#endregion
