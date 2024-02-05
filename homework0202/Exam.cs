using System;
namespace homework0202
{
	public class Exam
	{
		public Exam(string subject,DateTime examdate)
		{
			Subject = subject;
			ExamDate = examdate;
		}
		public string Subject { get; set; }
		public DateTime ExamDate { get; set; }

    }
}

