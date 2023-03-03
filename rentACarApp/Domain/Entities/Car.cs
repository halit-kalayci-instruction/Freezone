﻿using Domain.Enums;
using Freezone.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Car:Entity
{
    public int ModelId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }

    public CarState CarState { get; set; }

    public short MinFindeksCreditRate { get; set; }

    public ICollection<CarImage> Images { get; set; }
    public virtual Model? Model { get; set; }

    public Car()
    {
        Images = new HashSet<CarImage>();
    }
    public Car(int id, int modelId, int kilometer, short modelYear, string plate, short minFindeksCreditRate):this()
    {
        Id = id;
        ModelId = modelId;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
        MinFindeksCreditRate = minFindeksCreditRate;
    }
}