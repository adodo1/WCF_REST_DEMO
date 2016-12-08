降级说明:

1. web.config 去掉 <webHttp helpEnabled="true" automaticFormatSelectionEnabled="true"/>

2. svc 文件添加 Factory="System.ServiceModel.Activation.WebServiceHostFactory"



