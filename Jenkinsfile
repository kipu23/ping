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
                sh "git describe --tags --abbrev=0"
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
