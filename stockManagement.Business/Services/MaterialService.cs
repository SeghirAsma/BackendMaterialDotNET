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
    public class MaterialService : IMaterialsService
    {
        private readonly DBContextManagementStock _dbContext;
        public MaterialService(DBContextManagementStock dbContext) 
        {
            _dbContext = dbContext;
        }
        public Materials AddMaterials(Materials Materials)
        {
            try
            {
                //si notre objet Materials non null on fait l'ajout dans la bdd
                if (Materials != null)
                {
                    this._dbContext.Materials.Add(Materials);
                    this._dbContext.SaveChanges();
                }
                return Materials;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteMaterials(int id)
        {
            try
            {
                bool find = false;
                if (id !=0)
                {
                    Materials findMaterials = this._dbContext.Materials.Find(id);
                    if (findMaterials != null)
                    {
                        find = true;
                        this._dbContext.Materials.Remove(findMaterials);
                        this._dbContext.SaveChanges();
                    }
                }
                return find;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Materials> ListMaterials()
        {
            try
            {
                List<Materials> Materials = this._dbContext.Materials
                                                           //.Include(x => x.Assignment)
                                                           .ToList(); //tolist c'est l'une des linq: on l'utilise pour la recuperation des donnees depuis la bdd
                return Materials;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Materials UpdateMaterials(Materials Materials)
        {
            try
            {
                if (Materials != null)
                {
                    if (Materials.Id != 0)
                    {
                        this._dbContext.Materials.Update(Materials);
                        this._dbContext.SaveChanges();
                    }
                }
                return (Materials);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            }

        public Materials GetMaterialByld(int id)
        {
            try
            {
                Materials findMaterial = new Materials();
                if (id != 0)
                {
                    findMaterial = this._dbContext.Materials.FirstOrDefault(x => x.Id == id);

                }
                return findMaterial;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    }

