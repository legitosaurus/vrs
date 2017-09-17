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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRadar.Interface.Owin
{
    /// <summary>
    /// The interface for classes that can manipulate response streams.
    /// </summary>
    public interface IStreamManipulator
    {
        /// <summary>
        /// Gets the relative order in which this manipulator should be called relative to other manipulators. Lower values are called first.
        /// </summary>
        /// <remarks>
        /// Do not rely on this being referenced during individual calls - this might only be used when sorting stream manipulators
        /// as they are added to the configuration. It would be mildly expensive to keep sorting manipulators on every request.
        /// </remarks>
        int ResponseStreamPriority { get; }

        /// <summary>
        /// Called after all of the middleware has run for a request.
        /// </summary>
        /// <param name="environment">The OWIN environment for the request.</param>
        /// <remarks>
        /// The response stream will be positioned at the end of the content when the method is called. When the method
        /// returns the position should be at the end of the content. If the content is truncated then make sure you call
        /// SetLength before returning. Note that this is called unconditionally, including in the event of no valid
        /// response being returned.
        /// </remarks>
        void ManipulateResponseStream(IDictionary<string, object> environment);
    }
}
