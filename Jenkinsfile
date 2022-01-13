pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building...'
                sh "docker-compose -f docker-compose-build.yaml build --parallel"
            }
        }
        stage('Artifact') {
            steps {
                echo 'Creating artifacts...'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing...'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying...'
            }
        }
    }
}
