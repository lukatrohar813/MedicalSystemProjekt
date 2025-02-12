using AutoMapper;
using BL.Models;
using DAL.Model;

namespace BL.Mappings
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<MedicalHistory, MedicalHistoryDto>()
				.ForMember(dest => dest.Illness, opt => opt.MapFrom(src => src.Illness));

			CreateMap<Prescription, PrescriptionDto>()
				.ForMember(dest => dest.Medicine, opt => opt.MapFrom(src => src.Medicine));
			CreateMap<Patient, PatientDto>().ReverseMap();
			CreateMap<MedicalHistory, MedicalHistoryDto>().ReverseMap();
			CreateMap<Examination, ExaminationDto>().ReverseMap();
			CreateMap<ExaminationImage, ExaminationImageDto>().ReverseMap();
			CreateMap<Prescription, PrescriptionDto>().ReverseMap();
			CreateMap<Illness, IllnessDto>().ReverseMap();
			CreateMap<Medicine, MedicineDto>().ReverseMap();
		}
	}
}