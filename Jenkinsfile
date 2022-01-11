node('jenkins-slave') {
    
     stage('build') {
        sh(script: """
            git clone https://github.com/kipu23/ping-pong
            cd ./ping-pong
            docker-compose -f docker-compose-build.yaml build --parallel
        """)
    }
}