﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJudge.FormModels {
    public class ContestCreationFormData: IFormData{
        public string Title { set; get; }
        public string Description { set; get; }

        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
        
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        
        // list of problem id's to be included
        public IEnumerable<int> Problems { set; get; }

        public FormDataValidationResult Validate(){
            throw new NotImplementedException();
            return null;
        }
    }

    

}