// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tester.Integration.EfCore3
{
    // Harish3485
    public class Beta_Harish3485
    {
        public int Id { get; set; } // id (Primary key)
        public int AnotherId { get; set; } // another_id

        // Foreign keys

        /// <summary>
        /// Parent PropertyTypesToAdd pointed by [Harish3485].([AnotherId]) (FK_Harish)
        /// </summary>
        public virtual PropertyTypesToAdd PropertyTypesToAdd { get; set; } // FK_Harish
    }

}
// </auto-generated>