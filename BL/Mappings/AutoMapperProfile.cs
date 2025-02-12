using AutoMapper;
using BL.Models;
using DAL.Model;

namespace BL.Mappings
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{



			CreateMap<Patient, PatientDto>().ReverseMap();
			CreateMap<MedicalHistory, MedicalHistoryDto>().ReverseMap();
			CreateMap<Examination, ExaminationDto>().ReverseMap();
			CreateMap<ExaminationImage, ExaminationImageDto>().ReverseMap();
			CreateMap<Prescription, PrescriptionDto>().ReverseMap();
		}
	}
}
