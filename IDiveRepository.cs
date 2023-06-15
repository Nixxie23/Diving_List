﻿using System;
using System.Collections.Generic;
using Diving_List.Models;
namespace Diving_List
{
    public interface IDiveRepository
    {
        public IEnumerable<Dive> GetAllDives();
        public Dive GetDive(int id);
    }
}