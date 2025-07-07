using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Interfaces
{
    public interface IFileService
    {
        HospitalData LoadData();
        void SaveData(HospitalData data);
    }
}