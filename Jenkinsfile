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
                sh """
                    TAG=\$(git describe --tags --abbrev=0)
                    docker image tag ping-ms kipu23/ping-ms:\$TAG
                    docker image tag ping-ui kipu23/ping-ui:\$TAG
                    docker push kipu23/ping-ms:\$TAG
                    docker push kipu23/ping-ui:\$TAG
                """
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
