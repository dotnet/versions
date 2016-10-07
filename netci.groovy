import jobs.generation.Utilities

def project = GithubProject
def branch = GithubBranchName
def isPR = true

def newJobName = Utilities.getFullJobName(project, '', isPR)

def newJob = job(newJobName) {
    steps {
        batchFile('.\Maestro\build.cmd')
    }
}

Utilities.setMachineAffinity(newJob, 'Windows_NT', 'latest-or-auto')
Utilities.standardJobSetup(newJob, project, isPR, "*/${branch}")
Utilities.addGithubPRTriggerForBranch(newJob, branch, 'Windows build')
