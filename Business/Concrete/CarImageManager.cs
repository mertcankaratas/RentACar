﻿using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceded(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            var imagePathResult = FileUpload.Add(formFile);
            if (!imagePathResult.Success)
                return imagePathResult;

            carImage.ImagePath = imagePathResult.Data;
            carImage.Date = DateTime.Now;
                
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = GetCarImagePathIfExistById(carImage.CarImageId);
            if (!result.Success)
                return result;

            var deleteImageResult = FileUpload.Delete(result.Data);
            if (!deleteImageResult.Success)
            {
                return deleteImageResult;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var carImages = _carImageDal.GetAll(c => c.CarId == id);
            foreach (var carImage in carImages)
            {
                if (string.IsNullOrEmpty(carImage.ImagePath))
                {
                    carImage.ImagePath = FileUpload.GetDefaultImagePath();
                }
            }
            return new SuccessDataResult<List<CarImage>>(carImages,Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == id));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = GetCarImagePathIfExistById(carImage.CarImageId);
            if (!result.Success)
                return result;


            var updateImage = FileUpload.Update(formFile, result.Data);
            if (!updateImage.Success)
                return updateImage;

            carImage.ImagePath = updateImage.Data;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IDataResult<string>  GetCarImagePathIfExistById(int id)
        {
            var result = _carImageDal.Get(c => c.CarImageId == id);
            if(result == null)
            {
                return new ErrorDataResult<string>(Messages.CarNotFound);
            }
            return new SuccessDataResult<string>(result.ImagePath);
        }
    }

}
