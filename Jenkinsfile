node ('windows') {
    timestamps{
        stage('Checkout') {
            git credentialsId: 'joost-github', url: 'https://github.com/joostvdg/c-sharp-example-2.git'
        }

        def msbuildHome = tool name: 'default', type: 'hudson.plugins.msbuild.MsBuildInstallation'
        echo "msbuildHome=${msbuildHome}"
        def sonarHome = tool name: 'SonarQubeScannerMS', type: 'hudson.plugins.sonar.MsBuildSQRunnerInstallation'
        echo "sonarHome=${sonarHome}"

        dir('Coesd.Lib.Cs.ConsoleWrite') {
          stage('Lib::Sonar Start'){
              // start
              bat "\"${sonarHome}\\MSBuild.SonarQube.Runner.exe\" begin /key:CS-Example-2-Lib /name:CS-Example-2-Lib /version:1.0 /d:sonar.cs.xunit.reportsPaths=\"XUnitResults.xml\" /d:sonar.cs.opencover.reportsPaths=\"opencover.xml\""
          }

          stage('Lib::Build'){
              bat "\"${msbuildHome}\\msbuild\" /t:Rebuild /p:Configuration=Debug /p:Platform=x64"
          }

          stage('Lib::UnitTests') {
              bat '"C:\\Users\\Joost\\AppData\\Local\\Apps\\OpenCover\\OpenCover.Console.exe" -output:"opencover.xml" -register:Path64 -target:"packages\\xunit.runner.console.2.1.0\\tools\\xunit.console.exe" -targetargs:"Coesd.Lib.Cs.ConsoleWriteTest\\bin\\Debug\\Coesd.Lib.Cs.ConsoleWriteTest.dll -xml XUnitResults.xml -noshadow" -filter:"+[*]* -[Coesd.Lib.Cs.ConsoleWriteTest]*"'
          }

          stage('Lib::Sonar Finish'){
              // finish
              bat "\"${sonarHome}\\MSBuild.SonarQube.Runner.exe\" end"
          }

          stage('Lib::Publish NuGet Package') {
              withCredentials([[$class: 'FileBinding', credentialsId: 'nuget', variable: 'nuget']]) {
                  withCredentials([[$class: 'StringBinding', credentialsId: 'nuget-api-key', variable: 'key']]) {
                      println "env.nuget=${env.nuget}"
                      println "env.key=${env.key}"
                      bat "\"${msbuildHome}\\msbuild\" /t:Rebuild /p:Configuration=Release /p:Platform=x64"
                      bat "\"${env.nuget}\" pack Package.nuspec"
                      bat "\"${env.nuget}\" push c-sharp-example-2-Lib.1.0.0.nupkg ${env.key} -Source http://localhost:32769/repository/nuget-hosted"
                  }
              }
          }
        }

        dir('Coesd.Sse.Cs.Converse') {
          stage('Sse::Sonar Start'){
              // start
              bat "\"${sonarHome}\\MSBuild.SonarQube.Runner.exe\" begin /key:CS-Example-2-Sse /name:CS-Example-2-Sse /version:1.0"
          }

          stage('Sse::Build'){
              bat "\"${msbuildHome}\\msbuild\" /t:Rebuild /p:Configuration=Release /p:Platform=x64"
          }

          stage('Sse::Sonar Finish'){
              // finish
              bat "\"${sonarHome}\\MSBuild.SonarQube.Runner.exe\" end"
          }

          stage('Sse::Publish NuGet Package') {
              withCredentials([[$class: 'FileBinding', credentialsId: 'nuget', variable: 'nuget']]) {
                  withCredentials([[$class: 'StringBinding', credentialsId: 'nuget-api-key', variable: 'key']]) {
                      println "env.nuget=${env.nuget}"
                      println "env.key=${env.key}"
                      bat "\"${env.nuget}\" pack Package.nuspec"
                      bat "\"${env.nuget}\" push c-sharp-example-2-Sse.1.0.0.nupkg ${env.key} -Source http://localhost:32769/repository/nuget-hosted"
                  }
              }
          }
        }
    }
}
