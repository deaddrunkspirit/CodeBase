import react.RProps

external interface VideoPlayerProps : RProps {
    var video: Video
    var onWatchedButtonPressed: (Video) -> Unit
    var unwatchedVideo: Boolean
}