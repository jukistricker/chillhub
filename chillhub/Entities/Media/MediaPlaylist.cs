namespace chillhub.Entities.Media;

public class MediaPlaylist
{
    public Guid MediaId { get; set; }
    public Guid PlaylistId { get; set; }

    public Media? Media { get; set; }
    public Playlist? Playlist { get; set; }
}
