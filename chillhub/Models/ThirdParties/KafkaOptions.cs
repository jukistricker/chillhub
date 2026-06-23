namespace chillhub.Models.ThirdParties
{
    public class KafkaOptions
    {
        public const string SectionName = "Kafka";

        public string BootstrapServers { get; set; } = string.Empty;
        public string VideoTopic { get; set; } = "video-events";
    }
}
