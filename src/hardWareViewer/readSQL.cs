using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;

namespace hardWareViewer
{
    /**
     * \brief Класс для работы с базами данных.
     * 
     * Тут собраны все функции обращающиеся к базам данных
     */
    class readSQL
    {
        static ArrayList ap = new ArrayList();
        static SqlProvider sql = new SqlProvider(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

        static SqlProvider sql_dop = new SqlProvider(ConnectionSettings.GetServer("2"), ConnectionSettings.GetDatabase("2"), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

        #region "Справочник места положения оборудования"
        public static DataTable getLocation()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getLocation]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public static DataTable setLocation(int id, string cName, int type, bool isActive)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(type);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setLocation]",
                 new string[] { "@id", "@cName", "@type", "@isActive", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
        }
        #endregion

        #region "Справочник типа оборудования"
        public static DataTable getTypeHardWare()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getTypeHardWare]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public static DataTable setTypeHardWare(int id, string cName, int type, bool isActive, bool isComponent, string invCode)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(type);
            ap.Add(isActive);
            ap.Add(isComponent);
            ap.Add(invCode);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setTypeHardWare]",
                 new string[] { "@id", "@cName", "@type", "@isActive", "@isComponent", "@inventory", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.Int32, DbType.Boolean, DbType.Boolean, DbType.String, DbType.Int32 }, ap);
        }
        #endregion

        #region "Справочник типов комплектующих"
        public static DataTable getTypeComponents()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getTypeComponents]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public static DataTable setTypeComponents(int id, string cName, int type, bool isActive, string invCode)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(type);
            ap.Add(isActive);
            ap.Add(invCode);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setTypeComponents]",
                 new string[] { "@id", "@cName", "@type", "@isActive", "@inventory", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.Int32, DbType.Boolean, DbType.String, DbType.Int32 }, ap);
        }
        #endregion

        #region "Справочник объектов"
        /// <summary>
        /// Получение списка активных объектов
        /// </summary>
        /// <returns>Список активных значений</returns>
        public static DataTable getObject()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getObject]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        /// <summary>
        /// Получение значения текущего значения
        /// </summary>
        /// <returns>id объекта </returns>
        public static int getObject(int id)
        {
            ap.Clear();
            ap.Add(id);
            DataTable dtObject = sql.executeProcedure("[hardware].[getObject]",
                 new string[] { "@id" },
                 new DbType[] { DbType.Int32 }, ap);

            int ret_id = -1;

            if (dtObject != null && dtObject.Rows.Count > 0 && dtObject.Rows[0]["id"] != DBNull.Value)
               ret_id = Convert.ToInt32(dtObject.Rows[0]["id"].ToString().Trim());

            return ret_id;
        }

        /// <summary>
        /// Работа с объектом.
        /// </summary>
        /// Добавление / Изменение / Удаление
        /// <param name="id">id Объекта</param>
        /// <param name="cName">Имя объекта</param>
        /// <param name="type">Тип действия</param>
        /// <param name="isActive">Статус активно или нет</param>
        /// <returns>
        /// Возращает -2 если при редактировании данная запись уже есть
        /// Возращает настоящий id при успешном создании, изменении или удалении
        /// Возращает -3 если изменился статус
        /// Возращает -1 во всех остальных случаях
        /// </returns>
        public static DataTable setObject(int id, string cName, int type, bool isActive)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(type);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setObject]",
                 new string[] { "@id", "@cName", "@type", "@isActive", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
        }
        #endregion

        #region "Справочник комплектующих"
        public static DataTable getComponents()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getComponents]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public static DataTable setComponents(int id, string cName, string Description, int id_type, int type, bool isActive)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(Description);
            ap.Add(id_type);
            ap.Add(type);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setComponents]",
                 new string[] { "@id", "@cName", "@Description", "@id_type", "@type", "@isActive", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.Int32, DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
        }
        #endregion

        #region "Справочник железяк"
        public static DataTable getHardWare()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getHardWare]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public static DataTable setHardWare(int id, string cName, string Description, int id_type, int type, bool isActive)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(cName);
            ap.Add(Description);
            ap.Add(id_type);
            ap.Add(type);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setHardWare]",
                 new string[] { "@id", "@cName", "@Description", "@id_type", "@type", "@isActive", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.Int32, DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
        }

        public static DataTable getHardwareVsComponents(int id_hardware)
        {
            ap.Clear();
            ap.Add(id_hardware);
            return sql.executeProcedure("[hardware].[getHardwareVsComponents]",
                 new string[] { "@id_hardware" },
                 new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable setHardwareVsComponents(object id, int id_hardware, object id_component, int type)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_hardware);
            ap.Add(id_component);
            ap.Add(type);
            return sql.executeProcedure("[hardware].[setHardwareVsComponents]",
                 new string[] {"@id", "@id_hardware","@id_component","@type" },
                 new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }
        #endregion

        #region "Справочник МОП"
        public static DataTable getListResponsibles(int type)
        {
            ap.Clear();
            ap.Add(type);
            return sql.executeProcedure("[hardware].[getListResponsibles]",
                 new string[] { "@type" },
                 new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable setListResponsibles(int id, int id_kadr, int type, bool isActive)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_kadr);
            ap.Add(type);
            ap.Add(isActive);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setListResponsibles]",
                 new string[] { "@id", "@id_kadr", "@type", "@isActive", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Boolean, DbType.Int32 }, ap);
        }

        #endregion

        #region "Документы"
        public static DataTable getScan(int id_journal, int typeScan)
        {
            ap.Clear();
            ap.Add(id_journal);
            ap.Add(typeScan);
            return sql.executeProcedure("[hardware].[getScan]",
                 new string[] { "@id_journal", "@typeScan" },
                 new DbType[] { DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable setScan(int id_Journal, string cName, byte[] File, int TypeScan, int id, bool isDel)
        {
            ap.Clear();
            ap.Add(id_Journal);
            ap.Add(cName);
            ap.Add(File);
            ap.Add(TypeScan);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(id);
            ap.Add(isDel);
            return sql.executeProcedure("[hardware].[setScan]",
                 new string[] { "@id_Journal", "@cName", "@File", "@TypeScan", "@id_Creator", "@id", "@isDel" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.Binary, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Boolean }, ap);
        }

        #endregion

        #region "Смета"
        /// <summary>
        /// Запрос оборудования и комплектующих относящихся к смете
        /// </summary>
        /// <param name="id">id выбранной сметы</param>
        /// <returns>Возвращает таблицу оборудования и комплектующих</returns>
        public static DataTable getContentEstimate(int id = -1)
        {
            ap.Clear();
            ap.Add(id);
            return sql.executeProcedure("[hardware].[getContentEstimate]",
                 new string[] { "id" },
                 new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable getEstimate(DateTime dStart,DateTime dEnd)
        {
            ap.Clear();
            ap.Add(dStart);
            ap.Add(dEnd);
            return sql.executeProcedure("[hardware].[getEstimate]",
                 new string[] { "@dStart", "@dEnd" },
                 new DbType[] { DbType.Date, DbType.Date }, ap);
        }

        public static DataTable setEstimate(int id, string estimateName, string estimateDetail, DateTime date, string shipping, string delivery, int type, int id_dep, int id_object)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(estimateName);
            ap.Add(estimateDetail);
            ap.Add(date);
            ap.Add(shipping);
            ap.Add(delivery);
            ap.Add(type);
            ap.Add(id_dep);
            ap.Add(id_object);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setEstimate]",
                 new string[] { "@id", "@estimateName", "@estimateDetail", "@date", "@shipping", "@delivery", "@type", "@id_Dep", "@id_Object", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.Date, DbType.Decimal, DbType.Decimal, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable setContentEstimate(object id, int id_estimates, object id_components, object type_components,
            object price, object count, object link, object Description, int type, object status, object StatusConfirmation, object purchase, object delivery, object statusBuild, string comment)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_estimates);
            ap.Add(id_components);
            ap.Add(type_components);
            ap.Add(price);
            ap.Add(count);
            ap.Add(link);
            ap.Add(Description);
            ap.Add(status);
            ap.Add(StatusConfirmation);
            ap.Add(type);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(purchase);
            ap.Add(delivery);
            ap.Add(statusBuild);
            ap.Add(comment);

            return sql.executeProcedure("[hardware].[setContentEstimate]",
                 new string[] { "@id", "@id_estimates", "@id_components", "@type_components", "@price", 
                     "@count", "@link", "@Description","@status","@StatusConfirmation", "@type", "@idUser", "@purchase", "@delivery", "@statusBuild", "@comment" },
                 new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Boolean, DbType.Decimal, 
                     DbType.Decimal, DbType.String, DbType.String,DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Decimal, DbType.Boolean, DbType.String }, ap);
        }

        public static DataTable getStatus(string name)
        {
            ap.Clear();
            ap.Add(name);
            return sql.executeProcedure("[hardware].[getStatus]",
                 new string[] { "@name" },
                 new DbType[] { DbType.String }, ap);
        }

        public static DataTable changeStatusEstimate(int id, int id_status, string comment)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_status);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(comment);
            return sql.executeProcedure("[hardware].[changeStatusEstimate]",
                 new string[] { "@id", "@id_status", "@id_user", "@comment" },
                 new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.String }, ap);
        }

        public static DataTable getTableStatusEstimat(int id_status, int typeStatus)
        {
            ap.Clear();
            ap.Add(id_status);
            ap.Add(config.statusCode);
            ap.Add(typeStatus);
            return sql.executeProcedure("[hardware].[getTableStatusEstimate]",
                 new string[] { "@id_status", "@statusUser","@typeStatus" },
                 new DbType[] { DbType.Int32,DbType.String,DbType.Int32 }, ap);
        }

        public static DataTable setLinkEstimates(object id, int id_ContentEstimatesOld, int id_ComponentsHardwareNew, int type)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_ContentEstimatesOld);
            ap.Add(id_ComponentsHardwareNew);           
            ap.Add(type);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);

            return sql.executeProcedure("[hardware].[setLinkEstimates]",
                 new string[] { "@id", "@id_ContentEstimatesOld", "@id_ComponentsHardwareNew", "@type", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable setContentEstCvsH(int id_Component, int id_Hardware)
        {
            ap.Clear();
            ap.Add(id_Component);
            ap.Add(id_Hardware);

            return sql.executeProcedure("[hardware].[setContentEstCvsH]",
                 new string[] { "@id_component", "@id_hardware"},
                 new DbType[] { DbType.Int32, DbType.Int32}, ap);
        }

        public static DataTable updateSummaEstimate(int id, decimal summa)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(summa);
            return sql.executeProcedure("[hardware].[updateSummaEstimate]",
                 new string[] { "@id", "@summa" },
                 new DbType[] { DbType.Int32, DbType.Decimal }, ap);
        }


        public static DataTable changeStatusConfirmation(int id, int id_status)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_status);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add("");
            return sql.executeProcedure("[hardware].[changeStatusConfirmation]",
                 new string[] { "@id", "@id_status", "@id_user", "@comment" },
                 new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.String }, ap);
        }

        public static DataTable getListDepartmens()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getDepartmens]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public static DataTable getSingleDepartamens(int id)
        {
            ap.Clear();
            ap.Add(id);
            return sql.executeProcedure("[hardware].[getSingleDepartmens]",
                 new string[] { "@id" },
                 new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable getIdDep(int id)
        {
            ap.Clear();
            ap.Add(id);
            return sql.executeProcedure("[hardware].[getIdDep]",
                 new string[] { "@id" },
                 new DbType[] { DbType.Int64 }, ap);
        }

        public static int changeStatusPurchase(int id, int status)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(status);
            sql.executeProcedure("[hardware].[changeStatusPurchase]",
                new string[] { "@id", "@status" },
                new DbType[] { DbType.Int32, DbType.Int32 }, ap);
            return 0;
        }

        public static bool compareIdLinkEstimate(int oldId, int newId)
        {
            // Сравнение связей
            ap.Clear();
            ap.Add(oldId);
            ap.Add(newId);
            DataTable dtCompare = sql.executeProcedure("[hardware].[compareIdLinkEstimate]",
                new string[] {"@idOld", "@idNew"},
                new DbType[] {DbType.Int32, DbType.Int32}, ap);

            return Convert.ToBoolean(Convert.ToInt32(dtCompare.Rows[0]["id"].ToString()));
        }

        /**
         * <summary>Сравнение связей. Проверка существует ли создаваемая в смете связь между оборудованием и компонентами.</summary>
         * <param name="id_component">id Оборудования</param>
         * <param name="id_hardware">id Компонента</param>
         * <returns>Возращает True если связь существует и False если связи в таблице не обнаружено</returns>
         */
        public static bool compareContentEstCvsH(int id_component, int id_hardware)
        {
            ap.Clear();
            ap.Add(id_component);
            ap.Add(id_hardware);
            DataTable dtCompare = sql.executeProcedure("[hardware].[compareContentEstCvsH]",
                new string[] { "@id_component", "@id_hardware" },
                new DbType[] { DbType.Int32, DbType.Int32 }, ap);

            return Convert.ToBoolean(Convert.ToInt32(dtCompare.Rows[0]["id"].ToString()));
        }

        public static DataTable getLinkEstimate(int id)
        {
            // Получения связей
            ap.Clear();
            ap.Add(id);

            return sql.executeProcedure("[hardware].[getLinkEstimate]",
                new string[] { "@idNew" },
                new DbType[] { DbType.Int32 }, ap);
        }
        
        public static void deleteLinkEstimate(int idOld, int idNew)
        {
            // Удаление связей
            ap.Clear();
            ap.Add(idOld);
            ap.Add(idNew);

            sql.executeProcedure("[hardware].[deleteLinkEstimate]",
                new string[] {"@idOld", "@idNew"},
                new DbType[] {DbType.Int32, DbType.Int32}, ap);
        }

        /// <summary>
        /// Удаление связей
        /// </summary>
        /// <param name="ids">id оборудования или комплектующего в смете</param>
        /// <param name="type">0 - Оборудование, 1 - Комплектующие</param>
        public static void deleteContentEstCvsH(int ids, int type)
        {
            ap.Clear();
            ap.Add(ids);
            ap.Add(type);

            sql.executeProcedure("[hardware].[deleteContentEstCvsH]",
                new string[] {"@ids", "@type"},
                new DbType[] {DbType.Int32, DbType.Int32}, ap);
        }

        /// <summary>
        /// Удаление связей и оборудования.
        /// </summary>
        /// Удаляем связи и оборудование с не нужными статусами, нужные статусы приводим к 0.
        /// <param name="id">id сметы с которой проводится манипуляция</param>
        public static void deleteChangeEstimateCheck(int id)
        {
            
            ap.Clear();
            ap.Add(id);

            sql.executeProcedure("[hardware].[deleteListLinkEstimate]",
                new string[] {"@id"},
                new DbType[] {DbType.Int32}, ap);
            sql.executeProcedure("[hardware].[deleteListContentEstCvsH]",
                new string[] { "@id" },
                new DbType[] { DbType.Int32 }, ap);
            sql.executeProcedure("[hardware].[deleteListContentEstimate]",
                new string[] { "@id" },
                new DbType[] { DbType.Int32 }, ap);
            sql.executeProcedure("[hardware].[changeStatusListPurchase]",
                new string[] { "@id" },
                new DbType[] { DbType.Int32 }, ap);
        }

        /// <summary>
        /// Функция получения всех номеров смет с просрочной по постоновке на баланс
        /// </summary>
        /// <returns>Список id</returns>
        public static DataTable getExpBalance()
        {
            ap.Clear();

            return sql.executeProcedure("[hardware].[getExpBalance]",
                new string[] { },
                new DbType[] { }, ap);
        }

        #endregion

        #region "Акт приёмки передачи"

        public static DataTable getContentReceivingTransfer(int id_actReceivingTransfer)
        {
            ap.Clear();
            ap.Add(id_actReceivingTransfer);
            return sql.executeProcedure("[hardware].[getContentReceivingTransfer]",
                 new string[] { "id_actReceivingTransfer" },
                 new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable getActReceivingTransfer(DateTime dStart, DateTime dEnd)
        {
            ap.Clear();
            ap.Add(dStart);
            ap.Add(dEnd);
            return sql.executeProcedure("[hardware].[getActReceivingTransfer]",
                 new string[] { "@dStart", "@dEnd" },
                 new DbType[] { DbType.Date, DbType.Date }, ap);
        }

        public static DataTable setActReceivingTransfer(int id, string number, DateTime date, string comment,int status, int type)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(number);
            ap.Add(date);
            ap.Add(comment);
            ap.Add(status);
            ap.Add(type);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setActReceivingTransfer]",
                 new string[] { "@id", "@number", "@date", "@comment","@status", "@type", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.DateTime, DbType.String, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable setContentReceivingTransfer(int id, int id_ActReceivingTransfer, object id_Hardware, object TypeComponentsHardware,
            object id_Location, object id_Responsible, string comment, object PreviousStatus,
            object id_hardwareComponent,object id_estimateContent,object isZip, int type)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_ActReceivingTransfer);
            ap.Add(id_Hardware);
            ap.Add(TypeComponentsHardware);
            ap.Add(id_Location);
            ap.Add(id_Responsible);
            ap.Add(comment);
            ap.Add(PreviousStatus);
            ap.Add(id_hardwareComponent);
            ap.Add(id_estimateContent);
            ap.Add(isZip);
            ap.Add(type);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);

            return sql.executeProcedure("[hardware].[setContentReceivingTransfer]",
                 new string[] { "@id", "@id_ActReceivingTransfer", "@id_Hardware", "@TypeComponentsHardware", "@id_Location", "@id_Responsible", "@comment", "@PreviousStatus","@id_hardwareComponent","@id_estimateContent","@isZip", "@type", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Boolean, DbType.Int32, DbType.Int32, DbType.String, DbType.Int32, DbType.Int32, DbType.Int32,DbType.Boolean, DbType.Int32, DbType.Int32 }, ap);
        }

        #endregion
        
        #region "Акт инвентаризации"
        public static DataTable getDateInventory()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getDateInventory]",
                 new string[] { },
                 new DbType[] { }, ap);
        }

        public static DataTable setDayInventory(int id, DateTime date,int type)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(date);
            ap.Add(type);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setDayInventory]",
                 new string[] { "@id", "@date", "@type", "@idUser" },
                 new DbType[] {DbType.Int32,DbType.Date,DbType.Int32,DbType.Int32 }, ap);
        }
        
        public static DataTable getActInventory(int id_dayInventory)
        {
            ap.Clear();
            ap.Add(id_dayInventory);
            return sql.executeProcedure("[hardware].[getActInventory]",
                 new string[] {"@id_dayInventory" },
                 new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable getContentInventory(int id_actInventory)
        {
            ap.Clear();
            ap.Add(id_actInventory);
            return sql.executeProcedure("[hardware].[getContentInventory]",
                 new string[] { "@id_actInventory" },
                 new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable findJHardWare(string invNumber)
        {
            ap.Clear();
            ap.Add(invNumber);
            return sql.executeProcedure("[hardware].[findJHardWare]",
                 new string[] { "@invNumber" },
                 new DbType[] { DbType.String }, ap);
        }

        public static DataTable setActInventory(int id,int id_dayInventory, int number, DateTime date, string comment,int status, int type)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_dayInventory);
            ap.Add(number);
            ap.Add(date);
            ap.Add(comment);
            ap.Add(status);
            ap.Add(type);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setActInventory]",
                 new string[] { "@id","@id_dayInventory","@number","@date","@comment","@status", "@type", "@idUser" },
                 new DbType[] { DbType.Int32,DbType.Int32,DbType.Int32,DbType.Date,DbType.String,DbType.Int32,DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable setContentInventory(int id, int id_actInventory, int id_hardware, int status, int type)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_actInventory);
            ap.Add(id_hardware);          
            ap.Add(status);
            ap.Add(type);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setContentInventory]",
                 new string[] { "@id", "@id_actInventory", "@id_hardware", "@status", "@type", "@idUser" },
                 new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32,  DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }

        #endregion

        #region "Акт списания"

        public static DataTable getActWriteOff(DateTime dStart, DateTime dEnd)
        {
            ap.Clear();
            ap.Add(dStart);
            ap.Add(dEnd);
            return sql.executeProcedure("[hardware].[getActWriteOff]",
                 new string[] { "@dStart", "@dEnd" },
                 new DbType[] { DbType.Date, DbType.Date }, ap);
        }

        public static DataTable getActWriteOff(DateTime dStart, DateTime dEnd,int id)
        {
            ap.Clear();
            ap.Add(dStart);
            ap.Add(dEnd);
            ap.Add(id);


            return sql.executeProcedure("[hardware].[getActWriteOff]",
                 new string[] { "@dStart", "@dEnd", "@id" },
                 new DbType[] { DbType.Date, DbType.Date, DbType.Int32 }, ap);
        }

        public static DataTable getContentWriteOff(int id_ActWriteOff)
        {
            ap.Clear();
            ap.Add(id_ActWriteOff);
            return sql.executeProcedure("[hardware].[getContentWriteOff]",
                 new string[] { "@id_ActWriteOff" },
                 new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable setActWriteOff(int id,string Reason, bool isDel)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(Reason);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(isDel);
            return sql.executeProcedure("[hardware].[setActWriteOff]",
                 new string[4] { "@id", "@Reason", "@idUser","@isDel" },
                 new DbType[4] { DbType.Int32, DbType.String, DbType.Int32, DbType.Boolean }, ap);
        }

        public static DataTable setContentWriteOff(int id, int id_actWriteOff, int id_hardware)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_actWriteOff);
            ap.Add(id_hardware);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[setContentWriteOff]",
                 new string[4] { "@id", "@id_actWriteOff", "@id_hardware", "@idUser" },
                 new DbType[4] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable validateActWriteOff(int id)
        {
            ap.Clear();
            ap.Add(id);

            return sql.executeProcedure("[hardware].[validateActWriteOff]",
                 new string[1] { "@id" },
                 new DbType[1] { DbType.Int32 }, ap);
        }

        public static DataTable updateStatusActWriteOff(int id, int status)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(status);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);

            return sql.executeProcedure("[hardware].[updateStatusActWriteOff]",
                 new string[3] { "@id", "@status", "@id_user" },
                 new DbType[3] { DbType.Int32, DbType.Int32, DbType.Int32 }, ap);
        }

        #endregion

        #region "Список оборудования"

        public static DataTable getListHardWare()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getListHardWare]",
                 new string[] { },
                 new DbType[] { }, ap);
        }
        public static DataTable getSingleHardWare(object id_CH, object TypeCH)
        {
            ap.Clear();
            ap.Add(id_CH);
            ap.Add(TypeCH);
            return sql.executeProcedure("[hardware].[getSingleHardWare]",
                 new string[] {"@id_CH", "@TypeCH"},
                 new DbType[] {DbType.Int64, DbType.Int64}, ap);
        }

        public static DataTable GetRespInfo(int id)
        {
            ap.Clear();
            ap.Add(id);

            return sql.executeProcedure("[hardware].[GetRespInfo]",
                new string[] { "@id" }, new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable getInfoServiceRecordNumber(DateTime date,int number)
        {
            ap.Clear();
            ap.Add(date);
            ap.Add(number);

            return sql.executeProcedure("[hardware].[getInfoServiceRecordNumber]",
                new string[2] {"@date", "@number" }, new DbType[2] {DbType.Date, DbType.Int32 }, ap);
        }

        #endregion

        #region "Настройки"
        public static DataTable GetSettings(string id_value)
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(id_value);

            return sql.executeProcedure("[hardware].[GetSettings]",
                 new string[] {"@id_prog","@id_value" },
                 new DbType[] {DbType.Int32,DbType.String }, ap);
        }

        public static DataTable SetSettings(string id_value, string type_value, string value_name, string value, string comment)
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(id_value);

            ap.Add(type_value);
            ap.Add(value_name);
            ap.Add(value);
            ap.Add(comment);

            return sql.executeProcedure("[hardware].[SetSettings]",
                 new string[] { "@id_prog", "@id_value", "@type_value", "@value_name", "@value", "@comment" },
                 new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String }, ap);
        }

        #endregion

        #region "Данные по сканерам и пользователям"

        public static DataTable getDateUser(Int64 Code, Int64 numBaycik)
        {
            ap.Clear();
            ap.Add(Code);
            ap.Add(numBaycik);
            return sql.executeProcedure("[hardware].[getDateUser]", new string[2] { "@Code", "@numBaycik" }, new DbType[2] { DbType.Int64, DbType.Int64 }, ap);
        }

        public static DataTable getFioFromId(string stResponsible)
        {
            ap.Clear();
            ap.Add(stResponsible);
            return sql.executeProcedure("[hardware].[getFioFromId]", new string[] { "@fio" }, new DbType[] { DbType.String }, ap);

        }

        public static DataTable getLocationAdded(string stLocation)
        {
            ap.Clear();
            ap.Add(stLocation);
            return sql.executeProcedure("[hardware].[getLocationAdded]", new string[] { "@Loc" }, new DbType[] { DbType.String }, ap);
        }
        public static DataTable getHWAdded(string stEquipment)
        {
            ap.Clear();
            ap.Add(stEquipment);
            return sql.executeProcedure("[hardware].[getHWAdded]", new string[] { "@Eq" }, new DbType[] { DbType.String }, ap);
        }
        public static DataTable getComAdded(string stComponent)
        {
            ap.Clear();
            ap.Add(stComponent);
            return sql.executeProcedure("[hardware].[getComAdded]", new string[] { "@Com" }, new DbType[] { DbType.String }, ap);
        }


        public static DataTable setNewPositionAdded(int id, int id_Location, int id_ComponentsHardware, int id_Responsible, int TypeComponentsHardware, string cName, string InventoryNumber, bool isDel, object DatePurchase, object WarrantyPeriod, int? id_ListServiceRecords)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_Location);
            ap.Add(id_ComponentsHardware);
            ap.Add(id_Responsible);
            ap.Add(TypeComponentsHardware);
            ap.Add(cName);
            ap.Add(InventoryNumber);
            ap.Add(UserSettings.User.Id);
            ap.Add(isDel);
            ap.Add(DatePurchase);
            ap.Add(WarrantyPeriod);
            ap.Add(id_ListServiceRecords);

            return sql.executeProcedure("[hardware].[setNewPositionAdded]",
                new string[12] { "@id", "@id_Location", "@id_ComponentsHardware", "@id_Responsible", "@TypeComponentsHardware", "@cName", "@InventoryNumber", "@id_user", "@isDel", "@DatePurchase", "@WarrantyPeriod", "@id_ListServiceRecords" },
                new DbType[12] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.Int32, DbType.String, DbType.String, DbType.Int32, DbType.Boolean, DbType.Date, DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable getInventory(string stEquipment)
        {
            ap.Clear();
            ap.Add(stEquipment);
            return sql.executeProcedure("[hardware].[getInventory]", new string[] { "@Eq" }, new DbType[] { DbType.String }, ap);
        }

        public static DataTable getInventoryPrefix(string stEquipment)
        {
            ap.Clear();
            ap.Add(stEquipment);
            return sql.executeProcedure("[hardware].[getInventoryPrefix]", new string[] { "@Eq" }, new DbType[] { DbType.String }, ap);
        }

        public static DataTable getEquipmentList(int mod)
        {
            ap.Clear();
            ap.Add(mod);
            return sql.executeProcedure("[hardware].[getEquipmentList]", new string[] { "@mod" }, new DbType[] { DbType.Int32 }, ap);
        }

        public static DataTable getLocationList()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getLocationList]", new string[] { }, new DbType[] { }, ap);
        }

        public static DataTable getResponsibleList()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getResponsibleList]", new string[] { }, new DbType[] { }, ap);
        }

        public static DataTable deleteMessage(string cName, string InventoryNumber, int id)
        {
            ap.Clear();
            ap.Add(cName);
            ap.Add(InventoryNumber);
            ap.Add(id);
            return sql.executeProcedure("[hardware].[deleteMessage]", new string[] { "@cName", "@InventoryNumber", "@Id" }, new DbType[] { DbType.String, DbType.String, DbType.Int32 }, ap);
        }

        public static DataTable setNewPositionEdited(string idForEdit, string id_hardware, string isComponent, string cbEquipment, string tbInventory, string isActive, string id_Location, string tbName, string id_Kadr)
        {
            ap.Clear();
            ap.Add(idForEdit);
            ap.Add(id_hardware);
            ap.Add(isComponent);
            ap.Add(cbEquipment);
            ap.Add(tbInventory);
            ap.Add(isActive);
            ap.Add(id_Location);
            ap.Add(tbName);
            ap.Add(id_Kadr);
            return sql.executeProcedure("[hardware].[setNewPositionEdited]", new string[] { "@idForEdit", "@id_hardware", "@isComponent", "@cbEquipment", "@tbInventory", "@isActive", "@id_Location", "@tbName", "@id_Kadr" }, new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String }, ap);
        }

        public static DataTable getPositionEditedForm(string stInventory)
        {
            ap.Clear();
            ap.Add(stInventory);
            return sql.executeProcedure("[hardware].[getPositionEditedForm]", new string[] { "@tbInventory" }, new DbType[] { DbType.String }, ap);
        }

        public static DataTable getdateUnemploy(DateTime start, int idKadr)
        {
            ap.Clear();
            ap.Add(idKadr);
            ap.Add(start);
            return sql.executeProcedure("[hardware].[getdateUnemploy]",
                new string[2] { "@idKadr", "@date" },
                new DbType[2] { DbType.Int32, DbType.Date }, ap);
        }

        public static DataTable getDateTime()
        {
            ap.Clear();
            return sql.executeProcedure("[hardware].[getDateTime]", new string[0] { }, new DbType[0] { }, ap);
        }

        public static DataTable setInOutScan(int id_hardware, object UserGet, object UserOut, object DateGet, object DateOut, int id_kadr)
        {
            ap.Clear();
            ap.Add(id_hardware);
            ap.Add(UserGet);
            ap.Add(UserOut);
            ap.Add(DateGet);
            ap.Add(DateOut);
            ap.Add(id_kadr);

            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);

            return sql.executeProcedure("[hardware].[setInOutScan]",
                new string[] { "@id_hardware", "@UserGet", "@UserOut", "@DateGet", "@DateOut", "@id_kadr", "@id_user" },
                new DbType[] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.DateTime, DbType.DateTime, DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable getListScaners()
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            return sql.executeProcedure("[hardware].[getListScaners]", new string[1] { "@id_prog" }, new DbType[1] {DbType.Int32 }, ap);
        }

        public static DataTable getInOutScan(DateTime dateStart, DateTime dateEnd)
        {
            ap.Clear();
            ap.Add(dateStart);
            ap.Add(dateEnd);
            return sql.executeProcedure("[hardware].[getInOutScan]", new string[2] { "@dateStart", "@dateEnd" }, new DbType[2] { DbType.Date,DbType.Date }, ap);
        }

        public static DataTable getListScanersJournal()
        {
            ap.Clear();
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            return sql.executeProcedure("[hardware].[getListScanersJournal]", new string[1] { "@id_prog" }, new DbType[1] { DbType.Int32 }, ap);
        }

        #endregion

        #region ""
        public static DataTable getInventory_v1(int typeComp,int id_Comp)
        {
            ap.Clear();
            ap.Add(typeComp);
            ap.Add(id_Comp);
            return sql.executeProcedure("[hardware].[getInventory_v1]", 
                new string[2] { "@typeComp","@id_Comp" }, 
                new DbType[2] { DbType.Int32, DbType.Int32 }, ap);
        }

        public static DataTable checkInvNumber_v1(int typeComp, int id_Comp,string number,int id)
        {
            ap.Clear();
            ap.Add(typeComp);
            ap.Add(id_Comp);
            ap.Add(number);
            ap.Add(id);


            return sql.executeProcedure("[hardware].[checkInvNumber_v1]",
                new string[4] { "@typeComp", "@id_Comp","@number","@id" },
                new DbType[4] { DbType.Int32, DbType.Int32,DbType.String,DbType.Int32 }, ap);
        }

        public static DataTable setChangesHardware(int id_hard, string cName,object oldValue, object newValue,bool isDel)
        {
            ap.Clear();
            ap.Add(id_hard);
            ap.Add(cName);

            ap.Add(oldValue);
            ap.Add(newValue);
            ap.Add(isDel);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);

            return sql.executeProcedure("[hardware].[setChangesHardware]",
                new string[6] { "@id_hard", "@cName", "@oldValue", "@newValue", "@isDel", "@idUser" },
                new DbType[6] { DbType.Int32, DbType.String, DbType.String, DbType.String, DbType.Boolean, DbType.Int32 }, ap);
        }

        public static DataTable getReportHistory(int id_jHardWate,object dateStart,object dateEnd, object type)
        {
            ap.Clear();
            ap.Add(id_jHardWate);
            ap.Add(dateStart);
            ap.Add(dateEnd);
            ap.Add(type);

            return sql.executeProcedure("[hardware].[getReportHistory]", 
                new string[4] { "@id_jHardWate","@dateStart", "@dateEnd","@type" }, 
                new DbType[4] { DbType.Int32,DbType.Date,DbType.Date,DbType.Int32 }, ap);
        }

        #endregion

        #region "Расходные материалы"

        public static DataTable GetTypeOperation(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = sql.executeProcedure("[hardware].[GetTypeOperation]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            if (withAllDeps)
            {
                if (dtResult != null)
                {
                    if (!dtResult.Columns.Contains("isMain"))
                    {
                        DataColumn col = new DataColumn("isMain", typeof(int));
                        col.DefaultValue = 1;
                        dtResult.Columns.Add(col);
                        dtResult.AcceptChanges();
                    }

                    DataRow row = dtResult.NewRow();

                    row["cName"] = "Все типы";
                    row["id"] = 0;
                    row["isMain"] = 0;
                    dtResult.Rows.Add(row);
                    dtResult.AcceptChanges();
                    dtResult.DefaultView.RowFilter = "isActive = 1";
                    dtResult.DefaultView.Sort = "isMain asc, id asc";
                    dtResult = dtResult.DefaultView.ToTable().Copy();
                }
            }
            else
            {
                dtResult.DefaultView.RowFilter = "isActive = 1";
                dtResult.DefaultView.Sort = "id asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }

            return dtResult;
        }

        public static DataTable GetTypeBasic(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = sql.executeProcedure("[hardware].[GetTypeBasic]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            if (withAllDeps)
            {
                if (dtResult != null)
                {
                    if (!dtResult.Columns.Contains("isMain"))
                    {
                        DataColumn col = new DataColumn("isMain", typeof(int));
                        col.DefaultValue = 1;
                        dtResult.Columns.Add(col);
                        dtResult.AcceptChanges();
                    }

                    DataRow row = dtResult.NewRow();

                    row["cName"] = "Все типы";
                    row["id"] = 0;
                    row["isMain"] = 0;
                    dtResult.Rows.Add(row);
                    dtResult.AcceptChanges();
                    dtResult.DefaultView.RowFilter = "isActive = 1";
                    dtResult.DefaultView.Sort = "isMain asc, id asc";
                    dtResult = dtResult.DefaultView.ToTable().Copy();
                }
            }
            else
            {
                dtResult.DefaultView.RowFilter = "isActive = 1";
                dtResult.DefaultView.Sort = "id asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }

            return dtResult;
        }

        public static DataTable GetActiveMOL(bool withAllDeps = false)
        {
            ap.Clear();

            DataTable dtResult = sql.executeProcedure("[hardware].[GetActiveMOL]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            if (withAllDeps)
            {
                if (dtResult != null)
                {
                    if (!dtResult.Columns.Contains("isMain"))
                    {
                        DataColumn col = new DataColumn("isMain", typeof(int));
                        col.DefaultValue = 1;
                        dtResult.Columns.Add(col);
                        dtResult.AcceptChanges();
                    }

                    DataRow row = dtResult.NewRow();

                    row["cName"] = "Все";
                    row["id"] = 0;
                    row["isMain"] = 0;
                    dtResult.Rows.Add(row);
                    dtResult.AcceptChanges();
                    dtResult.DefaultView.RowFilter = "isActive = 1";
                    dtResult.DefaultView.Sort = "isMain asc, id asc";
                    dtResult = dtResult.DefaultView.ToTable().Copy();
                }
            }
            else
            {
                dtResult.DefaultView.RowFilter = "isActive = 1";
                dtResult.DefaultView.Sort = "id asc";
                dtResult = dtResult.DefaultView.ToTable().Copy();
            }

            return dtResult;
        }

        public static DataTable SetTMovementMaterial(int id, DateTime DateMovement,int id_TypeOperation,DateTime YearBasis, string NumberBase,int idBasis,string Comment)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(DateMovement);
            ap.Add(id_TypeOperation);
            ap.Add(YearBasis);
            ap.Add(NumberBase);
            ap.Add(idBasis);
            ap.Add(Comment);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[SetTMovementMaterial]",
                 new string[8] { "@id", "@DateMovement", "@id_TypeOperation", "@YearBasis", "@NumberBase", "@idBasis", "@Comment", "@id_user" },
                 new DbType[8] { DbType.Int32, DbType.Date, DbType.Int32, DbType.Date, DbType.String, DbType.Int32, DbType.String, DbType.Int32 }, ap);
        }

        public static DataTable ValidateLinkToNumberDoc(DateTime DateMovement, int NumberBase, int idBasis)
        {
            ap.Clear();
            ap.Add(NumberBase);
            ap.Add(DateMovement);            
            ap.Add(idBasis);

            if (idBasis == 2)
                return sql_dop.executeProcedure("[dbo].[ValidateLinkToNumberDoc]",
                     new string[3] { "@number", "@date", "@idBase" },
                     new DbType[3] { DbType.Int32, DbType.Date, DbType.Int32 }, ap);
            else
                return sql.executeProcedure("[hardware].[ValidateLinkToNumberDoc]",
                 new string[3] { "@number", "@date", "@idBase" },
                 new DbType[3] { DbType.Int32, DbType.Date, DbType.Int32 }, ap);
        }

        public static DataTable SetMovementMaterial(int id, int id_tMovementMaterial, int id_Material, decimal Count, int id_Responsible, string Comment)
        {
            ap.Clear();
            ap.Add(id);
            ap.Add(id_tMovementMaterial);
            ap.Add(id_Material);
            ap.Add(Count);
            ap.Add(id_Responsible);            
            ap.Add(Comment);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            return sql.executeProcedure("[hardware].[SetMovementMaterial]",
                 new string[7] { "@id", "@id_tMovementMaterial", "@id_Material", "@Count", "@id_Responsible", "@Comment", "@id_user" },
                 new DbType[7] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Decimal, DbType.Int32, DbType.String, DbType.Int32 }, ap);
        }

        public static DataTable GetMovementMaterial(int id_tMovementMaterial)
        {
            ap.Clear();
            ap.Add(id_tMovementMaterial);
            return sql.executeProcedure("[hardware].[GetMovementMaterial]",
                 new string[1] { "@id_tMovementMaterial"},
                 new DbType[1] { DbType.Int32}, ap);
        }


        #endregion
    }

    class config
    {
        public static string Reason = "";
        public static string centralText(string str)
        {
            int[] arra = new int[255];
            int count = 0;
            int maxLength = 0;
            int indexF = -1;
            arra[count] = 0;
            count++;
            indexF = str.IndexOf("\n");
            arra[count] = indexF;
            while (indexF != -1)
            {
                count++;
                indexF = str.IndexOf("\n", indexF + 1);
                arra[count] = indexF;
            }
            maxLength = arra[1] - arra[0];
            for (int i = 1; i < count; i++)
            {
                if (maxLength < (arra[i] - arra[i - 1]))
                {

                    maxLength = arra[i] - arra[i - 1];
                    if (i >= 2)
                    {
                        maxLength = maxLength - 1;
                    }
                }
            }
            string newString = "";
            string buffString = "";
            for (int i = 1; i < count; i++)
            {
                if (i >= 2)
                {

                    buffString = str.Substring(arra[i - 1] + 1, (arra[i] - arra[i - 1] - 1));
                    buffString = buffString.PadLeft(Convert.ToInt32(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2) * 1.8));
                    //    buffString = buffString.PadRight(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2)*2);
                    newString += buffString + "\n";
                }
                else
                {
                    buffString = str.Substring(arra[i - 1], arra[i]);
                    buffString = buffString.PadLeft(Convert.ToInt32(buffString.Length + ((maxLength - (arra[i] - arra[i - 1] - 1)) / 2) * 1.8));
                    // buffString = buffString.PadRight(buffString.Length + ((maxLength - (arra[i] - arra[i - 1])) / 2)*2);
                    newString = buffString + "\n";
                }

            }

            return newString;
        }

        public static string userName = "";
        public static string statusCode = "";
        public static string nameTable = "";

        public static int getExension(string _exension)
        {
            string docType = ".docx, .doc, .xlsx, .xls, .pdf, .vsd, .rtf";
            string imgType = "*.png, .jpg, .jpeg, .bmp";
            if (docType.Contains(_exension))
                return 1;
            else if (imgType.Contains(_exension))
                return 2;
            else
                return 2;
        }
    }
}
