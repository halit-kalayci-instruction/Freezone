using Application.Services.Repositories;
using Domain.Entities;
using Freezone.Core.Application.Rules;
using Freezone.Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules:BaseBusinessRules
    {
        private ICarRepository _carRepository;

        public CarBusinessRules(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task EachModelCanContainFiveCars(int modelId) 
        {
            var result = await _carRepository.GetListAsync(c=>c.ModelId == modelId);

            if (result.Count>=5)
            {
                throw new BusinessException("Each Model Can Contain Five Cars");
            }

        }

        public async Task CarMustExists(Car car)
        {
            if (car == null) throw new BusinessException("Can not find specified car");
        }
        public async Task CarMustBeAvailable(Car car)
        {
            if (car.CarState != Domain.Enums.CarState.Available) throw new BusinessException("This car is not available");
        }
    }
}
