namespace MedicalSystem.ViewModels.Examination
{
	public record ExaminationTypeOption(string Code, string Name)
	{
		public static string GetTypeName(string code)
		{
			return code switch
			{
				"GP" => "General Physical Examination",
				"KRV" => "Blood Test",
				"X-RAY" => "X-Ray",
				"CT" => "CT Scan",
				"MR" => "MRI Scan",
				"ULTRA" => "Ultrasound",
				"EKG" => "Electrocardiogram",
				"ECHO" => "Echocardiogram",
				"EYE" => "Eye Examination",
				"DERM" => "Dermatological Examination",
				"DENTA" => "Dental Examination",
				"MAMMO" => "Mammography",
				"NEURO" => "Neurological Examination",
				_ => code
			};
		}
	}
}

