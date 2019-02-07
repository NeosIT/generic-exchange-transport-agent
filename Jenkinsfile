#!/usr/bin/env groovy
library 'jenkins-pipeline-library'

def projectName = "generic-exchange-transport-agent"
def useVersion = version.uniqueBuildVersion()
def buildTargets = ['2010 SP3', '2016 RTM']

def	pipelineConfiguration = [
	config: [
		project: "${projectName}-build",
		debug: true,
		spinnakerName: "${projectName}",
		rocketChat: [
			channel: "kubedemo"
		],
		delivery: [
			files: [
				"**/*.msi": [
					archive: [
						enabled: true,
						mustExist: true
					],
					spinnaker: [
						type: "windows/msi",
						name: "${projectName}",
						reference: "${projectName}.msi",
						version: "${useVersion}"
					]
				],
			]
		]
	]
]

def workflow = workflow.createFromPipelineConfiguration(pipelineConfiguration)
workflow.context.config["type"] = ".NET binary build"
def msBuildConfiguration = msBuildConfiguration.create(workflow.context)

pipeline {
	agent {
		label 'dotnet'
	}

	parameters {
		/**
		 * When a webhook triggers, we can not specifiy which of the build targets have to run.
		 * Instead, we are compiling against all different versions and pushing them to the WooCommerce shop
		 */
		booleanParam(name: 'ALL_BUILDS', defaultValue: true, description: "Build for all targets")
		choice(name: 'BUILD_TARGET', choices: buildTargets, description: "Which Exchange version to use as build target, defaults to 2010 SP3")
	}

	stages {
		stage('Configure') {
			steps {
				script {
					workflow.configure(this)
				}
			}
		}

		stage('Checkout and import') {
			steps {
				script {
					workflow.initStage.run()
				}
			}
		}

		stage('Setting version') {
			steps {
				script {
					def useCommitHash = version.shortGitCommitHash()

					bat "powershell -File scripts/set-ci-versions.ps1 -BuildNumber ${useVersion} -Revision ${useCommitHash}"
				}
			}
		}

		stage('Build') {
			steps {
				script {
					/**
					 * This steps creates dynamically build stages based upon the given parameters
					 * @see https://devops.stackexchange.com/a/3090
					 */
					def useTargets = []
					def builds = [:]

					if (params.ALL_BUILDS) {
						// in case of ALL_BUILDS is checked, we use all available build targets
						useTargets = buildTargets
					}
					else {
						// use only the selected build target
						useTargets += params.BUILD_TARGET
					}

					// for each build target we create a new stage with the required build step
					for (buildTarget in useTargets) {
						def target = buildTarget

						builds["${target}"] = {

							node {
								label 'dotnet'
							}

							stage("Build target ${target}") {
								bat "powershell -File scripts/build.ps1 -BuildTarget \"${target}\" -ExchangeLibrariesPath c:\\exchange-libs"
							}
						 }
					}

					// execute each build target in parallel
					parallel builds
				}
			}
		}

		stage('Deliver artifacts to WooCommerce shop') {
			steps {
				script {
					workflow.deliveryStage.run()
				}
			}
		}

		stage('Collect delivered artifacts (local archiving, Spinnaker properties)') {
			steps {
				script {
					workflow.archiveStage.run()
				}
			}
		}
	}

	post {
		unstable {
			script {
				workflow.context.notifier.fail([title: 'Build Status', text: 'Build is unstable :-/'])
			}
		}

		failure {
			script {
				workflow.context.notifier.fail([title: 'Build Status', text: 'Build failed :-/'])
			}
		}

		success {
			script {
				workflow.context.notifier.ok([title: 'Build Status', text: 'Build succeeded :-)'])
			}
		}

		/*
		cleanup {
			script {
				cleanWs()
			}
		}
		*/
	}
}
