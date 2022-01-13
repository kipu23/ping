    stage('build') {
        sh(script: """
            git clone https://github.com/kipu23/ping
            cd ./ping
            docker-compose -f docker-compose-build.yaml build --parallel
        """)
    }
