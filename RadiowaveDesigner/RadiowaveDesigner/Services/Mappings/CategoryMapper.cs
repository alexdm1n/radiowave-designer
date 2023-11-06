using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Mappings;

internal class CategoryMapper : ICategoryMapper
{
    public Category Map(string categoryName)
    {
        return categoryName switch
        {
            "School" => Category.Schools,
            "Gymnasium" => Category.Schools,
            "Primary school" => Category.Schools,
            "University" => Category.University,
            "UniversityEducational center" => Category.University,
            "Shopping mall" => Category.Malls,
            "Hypermarket" => Category.Hypermarkets,
            "Food hypermarket" => Category.Hypermarkets,
            "Food hypermarketHypermarket" => Category.Hypermarkets,
            "Shopping mallHypermarket" => Category.Hypermarkets,
            "Polyclinic for adults" => Category.Clinics,
            "Children's polyclinic" => Category.Clinics,
            "Ambulatory care centre, first aid post" => Category.Clinics,
            "Medical center, clinic" => Category.Clinics,
            "Dental polyclinic" => Category.Clinics,
            "Hospital" => Category.Hospitals,
            "Specialized hospital" => Category.Hospitals,
            "Children's hospital" => Category.Hospitals,
            "HospitalMedical center, clinic" => Category.Hospitals,
            "HospitalAmbulance services" => Category.Hospitals,
            "Specialized hospitalHospital" => Category.Hospitals,
            "Park" => Category.Parks,
            "ParkAmusement park" => Category.Parks,
            "ParkUrban forest" => Category.Parks,
            "ParkSquare" => Category.Parks,
            "Urban forestParkSquare" => Category.Parks,
            "Urban forest" => Category.Parks,
            "Sports centerStadiumSports club" => Category.Stadiums,
            "Stadium" => Category.Stadiums,
            "Sports center" => Category.Arenas,
            "Railway station" => Category.TrainStations,
            "Railway stationRailway and air tickets" => Category.TrainStations,
            _ => Category.Undefined,
        };
    }
}