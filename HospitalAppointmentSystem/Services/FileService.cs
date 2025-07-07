using System;
using System.IO;
using HospitalAppointmentSystem.Helper;
using HospitalAppointmentSystem.Interfaces;
using HospitalAppointmentSystem.Models;

namespace HospitalAppointmentSystem.Services
{
    public class FileService : IFileService
    {
        private const string DataFolder = "Data";
        private const string FileName = "hospital.json";
        private readonly string _fullPath;

        public FileService()
        {
            Directory.CreateDirectory(DataFolder);
            _fullPath = Path.Combine(DataFolder, FileName);
        }

        public HospitalData LoadData()
        {
            return JsonHelper.Load<HospitalData>(_fullPath);
        }

        public void SaveData(HospitalData data)
        {
            JsonHelper.Save(data, _fullPath);
        }
    }
}