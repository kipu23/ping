pipeline {
    agent any

	environment {
		DOCKERHUB_CREDENTIALS=credentials('dockerhub-kipu23')
    }

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
                    echo \$DOCKERHUB_CREDENTIALS_PSW | docker login -u \$DOCKERHUB_CREDENTIALS_USR --password-stdin
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
