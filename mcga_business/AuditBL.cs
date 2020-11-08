using ArtEx.BL.Exceptions;
using ArtEx.BL.Models;
using mcga.interfaces;
using mcga.models;
using mcga.tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace ArtEx.BL
{
    
    public partial class BusinessContext
    {
        public List<AuditDVModel> checkAuditDV() 
        {
            List<AuditDVModel> result = new List<AuditDVModel>();
            List<User> users = listUsers("", "", 0, 0, 0);
            string dvv = "";
            foreach (var model in users)
            {
                if (!validateDVh(model))
                {
                    result.Add(new AuditDVModel() { tableName = "User", id = model.id, detail = "ERROR DVh", objectModel = model });
                }
                dvv += model.dv;
            }
            if (!validateDVv("User", dvv))
                result.Add(new AuditDVModel() { tableName = "User", detail = "ERROR DVv" });
            
            dvv = "";
            List<Product> products = listProducts("", "", 0, 0, 0);
            foreach (var model in products)
            {
                if (!validateDVh(model))
                {
                    result.Add(new AuditDVModel() { tableName = "Product", id = model.id, detail = "ERROR DVh", objectModel = model });
                }
                dvv += model.dv;
            }
            if (!validateDVv("Product", dvv))
                result.Add(new AuditDVModel() { tableName = "Product", detail = "ERROR DVv" });

            return result;
        }

        public bool createAuditDV()
        {
            string dvv = "";
            List<User> users = listUsers("", "", 0, 0, 0);
            foreach (var model in users)
            {
                updateDVh(model);
                dvv += model.dv;
            }
            updateDVv("User", dvv);

            dvv = "";
            List<Product> products = listProducts("", "", 0, 0, 0);
            foreach (var model in products)
            {
                updateDVh(model);
                dvv += model.dv;
            }
            updateDVv("Product", dvv);

            return true;
        }

        public bool validateDVh(IAudit model)
        {
            bool result = true;
            Type type = model.GetType();
            string tableName = getTableName(type);
            model.dv = generateDVh(model);
            AuditDvh currentDv = findDV(tableName, model.id.ToString());
            if (currentDv != null)
                result = model.dv == currentDv.dv;
            else
                result = false;

            return result;
        }

        public bool validateDVv(string tableName, string dvv)
        {
            bool result = true;
            dvv = Cryptog.EncriptarMD5(dvv);
            AuditDvh currentDv = findDV(tableName, "DVV");
            if (currentDv != null)
                result = dvv == currentDv.dv;
            else
                result = false;
            return result;
        }

        private  string generateDVh(IAudit model)
        {
            Type type = model.GetType();
            var properties = type.GetProperties();
            string dv = "";
            foreach (var property in properties)
            {
                try
                {
                    if (property.Name != "DV")
                    {
                        var value = type.GetProperty(property.Name).GetValue(model, null);
                        dv += value;
                    }
                }
                catch (Exception err)
                {

                }
            }
            model.dv = Cryptog.EncriptarMD5(dv);
            return model.dv;
        }

        private AuditDvh findDV(string tableName, string id)
        {
            try
            {
                AuditDvh result = db.DVHs.Where(x => x.tableName == tableName && x.id == id).FirstOrDefault();
                return result;
            }
            catch(Exception err)
            {
            }
            return null;
        }

        private void updateDVh(IAudit model)
        {
            try
            {
                generateDVh(model);
                Type type = model.GetType();
                string tableName = getTableName(type);
                AuditDvh dvh = findDV(tableName, model.id.ToString());
                if (dvh == null)
                {
                    dvh = new AuditDvh(tableName, model.id.ToString(), model.dv);
                    db.DVHs.Add(dvh);
                }
                else
                {
                    dvh.dv = model.dv;
                    db.Entry(dvh).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void updateDVv(string tableName, string dvv)
        {
            try
            {
                dvv = Cryptog.EncriptarMD5(dvv);
                AuditDvh dv = findDV(tableName, "DVV");
                if (dv == null)
                {
                    dv = new AuditDvh(tableName, "DVV", dvv);
                    db.DVHs.Add(dv);
                }
                else
                {
                    dv.dv = dvv;
                    db.Entry(dv).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private string getTableName(Type type)
        {
            if(type.BaseType.Name == "GenericAuditId")
                return type.Name;
            return type.BaseType.Name;
        }
    }
}
