using Microsoft.EntityFrameworkCore;
using stockManagement.Business.Interfaces;
using stockManagement.Data;
using stockManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stockManagement.Business.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly DBContextManagementStock _dbContext;
        public AssignmentService(DBContextManagementStock dbContext)
        {
            _dbContext = dbContext;
        }
        public Assignment AddAssignment(Assignment Assignment)
        {
            try
            { //si notre objet Assignment non null on fait l'ajout dans la bdd
                if (Assignment != null)
                {
                    this._dbContext.Assignment.Add(Assignment);
                    this._dbContext.SaveChanges();

                    var find = this._dbContext.Materials.Find(Assignment.IdMaterial);
                    if (find != null)
                    {
                        find.IsTaken = true;
                        this._dbContext.Materials.Update(find);
                        this._dbContext.SaveChanges();
                    }
                }
                return Assignment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteAssignment(int id)
        {
            try
            {
                bool find = false;
                if (id != 0)
                {
                    Assignment findAssignment = this._dbContext.Assignment.Find(id);
                    if (findAssignment != null)
                    {
                        var findMat = this._dbContext.Materials.Find(findAssignment.IdMaterial);
                      

                        find = true;
                        this._dbContext.Assignment.Remove(findAssignment);
                        this._dbContext.SaveChanges();

                        if (findMat != null)
                        {
                            findMat.IsTaken = false;
                            this._dbContext.Materials.Update(findMat);
                            this._dbContext.SaveChanges();
                        }
                    }
                }
                return find;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Assignment> ListAssignment()
        {
            try
            {
                List<Assignment> Assignment = this._dbContext.Assignment

                                                             .Include(X => X.Employee)
                                                             .Include(x => x.Materials)
                                                             .OrderBy(x=>x.IdEmployee)
                                                             .ToList(); //tolist c'est l'une des linq: on l'utilise pour la recuperation des donnees depuis la bdd
                return Assignment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Assignment UpdateAssignment(Assignment Assignment)
        {
            try
            {
                if (Assignment != null)
                {
                    if (Assignment.Id != 0)
                    {
                        //this._dbContext.Update(Assignment);
                        this._dbContext.Entry<Assignment>(Assignment).State = EntityState.Modified;
                        this._dbContext.SaveChanges();
                    }
                }
                return (Assignment);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        
    }

    }

        

