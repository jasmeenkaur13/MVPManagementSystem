#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModels.GenericRepository;

#endregion

namespace DataModels.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private CarSalesEntities _context = null;
        private GenericRepository<Owner> _ownerRepository;
        private GenericRepository<AdvertisedCar> _carRepository;
        private GenericRepository<Owners_Cars_Ref> _carOwnerRefRepository;
        private GenericRepository<Enquiry> _enquiryRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new CarSalesEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<Enquiry> EnquiryRepository
        {
            get
            {
                if (this._enquiryRepository == null)
                    this._enquiryRepository = new GenericRepository<Enquiry>(_context);
                return _enquiryRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<AdvertisedCar> AdvertsedCarRepository
        {
            get
            {
                if (this._carRepository == null)
                    this._carRepository = new GenericRepository<AdvertisedCar>(_context);
                return _carRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Owner> OwnerRepository
        {
            get
            {
                if (this._ownerRepository == null)
                    this._ownerRepository = new GenericRepository<Owner>(_context);
                return _ownerRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public GenericRepository<Owners_Cars_Ref> CarOwnerRepository
        {
            get
            {
                if (this._carOwnerRefRepository == null)
                    this._carOwnerRefRepository = new GenericRepository<Owners_Cars_Ref>(_context);
                return _carOwnerRefRepository;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
