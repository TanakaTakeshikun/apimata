using Microsoft.AspNetCore.Mvc;
using AI.Talk.Editor.Api;

namespace test.Controllers
{

    public class Rqdata
    {
        public int Pitch { get; set; }

        public string? Text { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class KuronekoController : ControllerBase
    {
        private TtsControl? _ttsControl;
        private string Startup()
        {
            _ttsControl = new TtsControl();
            _ttsControl.Initialize("A.I.VOICE Editor");
            if (_ttsControl.Status == HostStatus.NotRunning)
            {
                // ホストプログラムを起動する
                _ttsControl.StartHost();
            }
            _ttsControl.Connect();//ここでエラー
            return "test";

        }
        [HttpGet]
        public Rqdata Get(int Pitch)
        {
            Rqdata pd = new()
            {
                Pitch = Pitch,
                Text = this.Startup()
            };
            return pd;
        }
    }
}