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
          parrallel {
            stage('editMode'){
                sh 'echo "editMode..."'
            }
            stage('playMode'){
                sh 'echo "playMode..."'
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
