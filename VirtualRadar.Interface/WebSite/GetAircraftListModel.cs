﻿// Copyright © 2017 onwards, Andrew Whewell
// All rights reserved.
//
// Redistribution and use of this software in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//    * Neither the name of the author nor the names of the program's contributors may be used to endorse or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHORS OF THE SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRadar.Interface.WebSite
{
    /// <summary>
    /// The model that carries arguments to the endpoints that fetch aircraft lists.
    /// </summary>
    public class GetAircraftListModel
    {
        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public long LastDataVersion { get; set; } = -1L;

        public long ServerTicks { get; set; } = -1L;

        public bool ResendTrails { get; set; }

        public int SelectedAircraft { get; set; } = -1;

        public bool FlightSimulator { get; set; }

        public List<GetAircraftListFilter> Filters { get; set; } = new List<GetAircraftListFilter>();

        public TrailType TrailType { get; set; }

        public List<GetAircraftListSortByModel> SortBy { get; set; } = new List<GetAircraftListSortByModel>();
    }

    public class GetAircraftListSortByModel
    {
        public string Col { get; set; }

        public bool Asc { get; set; } = true;
    }
}
