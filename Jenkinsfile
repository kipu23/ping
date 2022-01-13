pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building...'
                step([$class: 'DockerComposeBuilder', dockerComposeFile: 'docker-compose-build.yaml', option: [$class: 'StartAllServices'], useCustomDockerComposeFile: true])
            }
            
        }
        stage'Artifact') {
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
