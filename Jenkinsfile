pipeline {
    agent any
    stages {
        stage('build') {
            steps {
              sh 'echo "building..."'
            }
        }
        stage('test') {
//    agent { docker { image 'docker' } }
          failFast true
          parallel 
          {
            stage('editMode')
            {
    agent { docker { image 'gableroux/unity3d' } }
              steps {
                sh 'echo "editMode..."'
              }
            }
            stage('playMode')
            {
    agent { docker { image 'gableroux/unity3d' } }
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
