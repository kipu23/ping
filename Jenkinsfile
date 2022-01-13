pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                sh(script: """
                cd ./ping
                docker-compose -f docker-compose-build.yaml build --parallel
                """)
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}
