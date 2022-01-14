pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building...'
                sh """
                    TAG=\$(git describe --tags --abbrev=0)
                    docker-compose -f docker-compose-build.yaml build --parallel
                """
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
