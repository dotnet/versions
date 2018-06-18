// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.DotNet.Maestro.WebApi.Models
{
    public class ModifiedFileModel
    {
        public string FullPath { get; set; }

        public string RepoName { get; set; }

        public string BranchName { get; set; }

        public string CommitId { get; set; }

        public string CommitList { get; set; }

        public static bool TryParse(
            string repoFullName,
            string refSpec,
            string fullPath,
            Commit commit,
            IEnumerable<Commit> commits,
            out ModifiedFileModel model)
        {
            // the file path goes like the following:
            // https://github.com/<owner>/<repo>/blob/<branch>/<fullPath>
            // NOTE: only supports github files for now.

            model = null;

            if (!refSpec.StartsWith("refs/heads/"))
            {
                Trace.TraceError($"Invalid RefSpec - expecting to start with 'refs/heads/': '{refSpec}'");
                return false;
            }

            string branchName = refSpec.Substring("refs/heads/".Length);

            model = new ModifiedFileModel()
            {
                RepoName = repoFullName,
                BranchName = branchName,
                FullPath = "https://github.com/" + string.Join("/", repoFullName, "blob", branchName, fullPath),
                CommitId = commit.id,
                CommitList = string.Join(";", commits.Select( c => c.id ))
            };

            return true;
        }
    }
}