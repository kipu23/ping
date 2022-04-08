
# Create AKS cluster

- install azure cli (https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=azure-cli)
  **az account list --output table**
  **az account set --subscription "My Demos"**

- create cluster (https://docs.microsoft.com/en-us/azure/aks/kubernetes-walkthrough-portal)
  - Networking: Enable HTTP application routing=true
  - you need only one node for development

- install kubectl (https://kubernetes.io/docs/tasks/tools/install-kubectl-windows/)
    **az aks get-credentials --resource-group <resource_group> --name <cluster_name>**

- configure kubectl for multiple clusters (https://kubernetes.io/docs/tasks/access-application-cluster/configure-access-multiple-clusters/)


# install loki stack (grafana, loki, prometheus)
(https://grafana.com/docs/loki/latest/installation/helm/)

**helm repo add grafana https://grafana.github.io/helm-charts**

**helm repo update**

**helm upgrade --install loki --namespace=monitoring grafana/loki-stack --set grafana.enabled=true,prometheus.enabled=true,prometheus.alertmanager.persistentVolume.enabled=false,prometheus.server.persistentVolume.enabled=false,promtail.enabled=false**

- reach grafana ui
  - search for the DNS zone in the newly created MC_<resource_group>_<cluster_name>_westeurope
  - note the id in front of .westeurope.aksapp.io 
  - create an ingress (grafana-ingress.yaml) for grafana with:
    - host named grafana.<dns_id>.westeurope.aksapp.io, using the id from the previous step,
    - grafana service name (kubectl get svc -> loki-grafana)
    - namespace=monitoring
  - search for the DNS zone, and add record set with
    - type A.
    - IP address is the public ip of the ingress controller (kubectl get ingress will tell you)
  - get the admin password
    **kubectl get secret --namespace monitoring loki-grafana -o jsonpath="{.data.admin-password}"**
    decode the admin password, because it is base64 encoded!
  - you can reach grafana with the host set in the grafana-ingress.yaml: grafana.<dns_id>.westeurope.aksapp.io



















OLD WAY:
# install prometheus stack into *monitoring* namespace
(https://www.youtube.com/watch?v=QoDqxm7ybLc&t=1s)

- create new namespace for prometheus
  - kubectl create namespace monitoring
  - kubectl config set-context --current --namespace=monitoring
  
-  install prometheus stack (https://github.com/prometheus-community/helm-charts/tree/main/charts/kube-prometheus-stack)
  - helm repo add prometheus-community https://prometheus-community.github.io/helm-charts
  - helm repo update
  - helm install prometheus prometheus-community/kube-prometheus-stack

- reach grafana ui
  - search for the DNS zone in the newly created MC_<resource_group>_<cluster_name>_westeurope
  - note the id in front of .westeurope.aksapp.io 
  - create an ingress (grafana-ingress.yaml) for grafana with host named grafana.<dns_id>.westeurope.aksapp.io, using the id from the previous step
  - search for the DNS zone, and add record set with
    - type A.
    - IP address is the public ip of the ingress controller (kubectl get ingress will tell you)
  - default pass: admin/prom-operator