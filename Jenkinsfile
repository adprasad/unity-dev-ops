pipeline {
    agent { docker { image 'gableroux/unity3d' } }
    stages {
        stage('build') {
            steps {
              gitStatusWrapper(credentialsId: 'github-unity-dev-ops', gitHubContext: 'Status', description: 'Validating') {
                sh 'echo "building..."'
              }
            }
        }
        stage('test') {
          failFast true
          parallel 
          {
            stage('editMode')
            {
              steps {
                sh 'echo "editMode..."'
              }
            }
            stage('playMode')
            {
              steps {
                sh 'echo "playMode..."'
              }
            }
          }
        }
    }
    post { 
        always { 
            echo 'Try to update github status'
            
        }
    }
}
