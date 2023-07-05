package factories;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

public class TestsConfig {
    protected static FileInputStream stream;
    protected static Properties properties;
    static {
        try {
            stream = new FileInputStream(TestsConfig.class.getResource("/config.properties").getFile());
            properties = new Properties();
            properties.load(stream);
        }
        catch (IOException ex) {
            ex.printStackTrace();
        }
        finally {
            if (stream != null) {
                try {
                    stream.close();
                }
                catch (IOException ex) {
                    ex.printStackTrace();
                }
            }
        }
    }

    public static String getProperty(String key) {
        return properties.getProperty(key);
    }
}
